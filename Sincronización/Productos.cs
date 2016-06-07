using Objects;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Sincronización
{
    public class Productos : Base
    {
        private string connectionStringtest = GetConnectionString();
        private ProductoLista.ProductoLista_Service servLista;
        private ProductoFicha.ProductoFicha_Service servFicha;
        private ProductoImagen.ProductoImagen_Service servImagen;
        private ProductoTraduccion.ProductoTraduccion_Service servTraduccion;
        private ProductoCaracteristicas.ProductoCaracteristica_Service servTextos;
        ProductoTraduccion.ProductoTraduccion[] productoTraducciones;
        OleDbConnection connection;
        List<Producto> productos = null;

        public Productos()
        {
            servLista = new ProductoLista.ProductoLista_Service();
            servLista.Credentials = GetNetworkCredential();
            servLista.Url = "http://192.168.1.202:7047/InstanceName/WS/MAI%20AUTOPARTS%2C%20S.L./Page/ProductoLista";

            servFicha = new ProductoFicha.ProductoFicha_Service();
            servFicha.Credentials = GetNetworkCredential();
            servFicha.Url = "http://192.168.1.202:7047/InstanceName/WS/MAI%20AUTOPARTS%2C%20S.L./Page/ProductoFicha";

            servImagen = new ProductoImagen.ProductoImagen_Service();
            servImagen.Credentials = GetNetworkCredential();
            servImagen.Url = "http://192.168.1.202:7047/InstanceName/WS/MAI%20AUTOPARTS%2C%20S.L./Page/ProductoImagen";

            servTraduccion = new ProductoTraduccion.ProductoTraduccion_Service();
            servTraduccion.Credentials = GetNetworkCredential();
            servTraduccion.Url = "http://192.168.1.202:7047/InstanceName/WS/MAI%20AUTOPARTS%2C%20S.L./Page/ProductoTraduccion";

            servTextos = new ProductoCaracteristicas.ProductoCaracteristica_Service();
            servTextos.Credentials = GetNetworkCredential();
            servTextos.Url = "http://192.168.1.202:7047/InstanceName/WS/MAI%20AUTOPARTS%2C%20S.L./Page/ProductoCaracteristica";
        }

        public bool SincroProductos()
        {
            return ActualizarProductos() && EliminarProductos() && ActualizarTextos();
        }

        private List<Producto> GetProductos()
        {
            if (productos == null)
            {
                productos = new List<Producto>();
                connection = new OleDbConnection(GetConnectionString());

                List<ProductoLista.ProductoLista_Filter> filters = new List<ProductoLista.ProductoLista_Filter>();
                ProductoLista.ProductoLista_Filter filter = new ProductoLista.ProductoLista_Filter();
                filter.Field = ProductoLista.ProductoLista_Fields.Producto_web;
                filter.Criteria = "=true";
                filters.Add(filter);


                //ProductoLista.ProductoLista_Filter filter2 = new ProductoLista.ProductoLista_Filter();
                //filter2.Field = ProductoLista.ProductoLista_Fields.No;
                //filter2.Criteria = "=04AM";
                //filters.Add(filter2);

                ProductoLista.ProductoLista[] productoLista = servLista.ReadMultiple(filters.ToArray(), null, 0);
                connection.Open();
                foreach (var product in productoLista)
                {
                    ProductoFicha.ProductoFicha productoFicha = servFicha.Read(product.No);

                    if (product.Producto_web && !product.Blocked && !productoFicha.Pendiente_de_edicion)
                    {
                        Producto producto = new Producto();
                        producto.Multiple = int.Parse(productoFicha.Cantidad_múltiplo_ventas.ToString());
                        producto.Referencia = product.No;
                        producto.Descripcion = product.Description;
                        producto.Descripcion2 = product.Description_2;
                        producto.Precio = product.Unit_Price;
                        producto.Stock = Convert.ToInt32(product.Inventory);
                        producto.ProductoWeb = product.Producto_web;
                        producto.ParaSubir = !Existe(producto.Referencia);
                        producto.Familia = int.Parse(product.Item_Category_Code);
                        producto.SubFamilia = int.Parse(product.Product_Group_Code);
                        producto.ActualizarTextos = productoFicha.Actualizar_textos;

                        //la imagen la cojo del web service de la imagen
                        string id = servImagen.GetRecIdFromKey(product.Key);
                        ProductoImagen.ProductoImagen productoImagen = servImagen.ReadByRecId(id.ToUpper());
                        producto.Imagen = productoImagen.Key;
                        //TODO: Convertir clave de imagenes a imagen (o directorio...), desencriptar


                        producto.Traducciones = GetTraducciones(producto.Referencia);

                        productos.Add(producto);
                    }
                }
                Console.WriteLine("Todos los productos han sido recogidos correctamente");
                connection.Close();
            }

            return productos;
        }

        private List<ProductoCaracteristicas.ProductoCaracteristica> GetTextos(string referencia)
        {
            List<ProductoCaracteristicas.ProductoCaracteristica> textos = new List<ProductoCaracteristicas.ProductoCaracteristica>();

            List<ProductoCaracteristicas.ProductoCaracteristica_Filter> filtros = new List<ProductoCaracteristicas.ProductoCaracteristica_Filter>();
            ProductoCaracteristicas.ProductoCaracteristica_Filter filtro1 = new ProductoCaracteristicas.ProductoCaracteristica_Filter();

            filtro1.Field = ProductoCaracteristicas.ProductoCaracteristica_Fields.N_x00BA__producto;
            filtro1.Criteria = "=" + referencia;
            filtros.Add(filtro1);

            textos = servTextos.ReadMultiple(filtros.ToArray(), null, 0).ToList();

            return textos;
        }

        private List<Traduccion> GetTraducciones(string referencia)
        {
            //solo coge las traducciones nuevas / actualizadas
            List<Traduccion> traducciones = new List<Traduccion>();
            Traduccion traduccion;

            if (productoTraducciones == null)
                productoTraducciones = servTraduccion.ReadMultiple(null, null, 0);

            IEnumerable<ProductoTraduccion.ProductoTraduccion> traduccionQuery =
                from translation in productoTraducciones
                where translation.Item_No.ToString() == referencia
                select translation;

            foreach (ProductoTraduccion.ProductoTraduccion trans in traduccionQuery)
            {
                if (!ExisteTraduccion(trans.Item_No, trans.Language_Code, trans.Description))
                {
                    traduccion = new Traduccion();
                    traduccion.Idioma = trans.Language_Code;
                    traduccion.Texto = trans.Description;
                    traducciones.Add(traduccion);
                }
            }
            return traducciones;
        }

        private bool Existe(string referencia)
        {
            using (OleDbCommand command = new OleDbCommand())
            {
                StringBuilder query = new StringBuilder();
                query.Append("SELECT ProductGuid ");
                query.Append("FROM ProductTable ");
                query.Append("WHERE ProductGuid = @ProductGuid");

                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = query.ToString();
                command.Parameters.Add(new OleDbParameter("@ProductGuid", referencia));

                return (command.ExecuteScalar() != null);
            }
        }

        private bool ExisteTraduccion(string referencia, string idioma, string traduccion)
        {
            using (OleDbCommand command = new OleDbCommand())
            {
                StringBuilder query = new StringBuilder();
                query.Append("SELECT * ");
                query.Append("FROM ProductTranslation ");
                query.Append("WHERE ProductGuid = @ProductGuid ");
                query.Append("AND LanguageGuid = @LanguageGuid ");
                query.Append("AND ProductName = @ProductName");

                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = query.ToString();
                command.Parameters.Add(new OleDbParameter("@ProductGuid", referencia));
                command.Parameters.Add(new OleDbParameter("@LanguageGuid", idioma));
                command.Parameters.Add(new OleDbParameter("@ProductName", traduccion));

                return (command.ExecuteScalar() != null); //TODO: Añadir marcador de si existe y es diferente / no existe / existe...
            }
        }

        private List<string> GetReferencias()
        {
            List<string> referencias = new List<string>();
            using (OleDbCommand command = new OleDbCommand())
            {
                StringBuilder query = new StringBuilder();
                query.Append("SELECT ProductGuid ");
                query.Append("FROM ProductTable");

                command.CommandText = query.ToString();
                OleDbDataReader reader = null;
                command.Connection = connection;

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    referencias.Add(reader["productguid"].ToString());

                }
            }
            return referencias;
        }

        private bool ExisteNav(string referencia)
        {
            bool existe = false;
            ProductoLista.ProductoLista producto = servLista.Read(referencia);
            if (producto != null)
                existe = producto.Producto_web;
            return existe;
        }

        private void EliminarProducto(string referencia)
        {
            using (OleDbCommand command = new OleDbCommand())
            {
                StringBuilder query = new StringBuilder();
                query.Append("DELETE FROM ProductTable ");
                query.Append("WHERE ProductGuid = @ProductGuid; ");

                command.CommandText = query.ToString();
                command.Parameters.Add(new OleDbParameter("@ProductGuid", referencia));
                command.Connection = connection;

                command.ExecuteNonQuery();

                query = new StringBuilder();
                query.Append("DELETE FROM GroupProduct ");
                query.Append("WHERE ProductGuid = @ProductGuid");
                command.ExecuteNonQuery();
            }

        }

        public bool ActualizarProductos()
        {
            bool correcto;
            string sortIndex = "";
            string navisionFamSubFamId = "";
            string groupProductGuid = "";
            string groupGuid = "";

            List<Producto> productos = new List<Producto>();
            productos = GetProductos();

            try
            {
                using (OleDbConnection connection = new OleDbConnection(GetConnectionString()))
                {
                    connection.Open();
                    foreach (Producto producto in productos)
                    {
                        navisionFamSubFamId = producto.Familia + "_" + producto.SubFamilia;

                        if (producto.ParaSubir)
                        {
                            Console.WriteLine("Se va a subir el siguiente producto: " + producto.Referencia);
                            #region Recoger Parámetros necesarios de BD

                            //groupguid
                            using (OleDbCommand command = new OleDbCommand())
                            {
                                StringBuilder query = new StringBuilder();

                                query.Append("SELECT GroupGuid ");
                                query.Append("FROM GroupTable ");
                                query.Append("WHERE NavisionId = @NavisionId ");

                                command.CommandText = query.ToString();
                                command.Parameters.Add(new OleDbParameter("@NavisionId", navisionFamSubFamId));
                                command.Connection = connection;
                                OleDbDataReader reader = null;

                                reader = command.ExecuteReader();
                                while (reader.Read())
                                    groupGuid = reader["GroupGuid"].ToString();

                                reader = null;
                            }

                            //sortindex, grouproductguid
                            using (OleDbCommand command = new OleDbCommand())
                            {
                                StringBuilder query = new StringBuilder();
                                query.Append("SELECT MAX(sortindex) as [sortindex], MAX(groupproductguid) as [groupproductguid] ");
                                query.Append("FROM GroupProduct");

                                command.CommandText = query.ToString();
                                command.Connection = connection;
                                OleDbDataReader reader = null;

                                reader = command.ExecuteReader();
                                while (reader.Read())
                                {
                                    sortIndex = (int.Parse(reader["sortindex"].ToString()) + 1).ToString();
                                    groupProductGuid = (int.Parse(reader["groupproductguid"].ToString()) + 1).ToString();
                                }

                            }

                            #endregion

                            #region Insert a GroupProduct

                            using (OleDbCommand command = new OleDbCommand())
                            {
                                StringBuilder query = new StringBuilder();
                                query.Append("INSERT INTO GroupProduct ");
                                query.Append("(GroupProductGuid, GroupGuid, ProductGuid, SortIndex, NavisionFamSubFamId) ");
                                query.Append("VALUES(@GroupProductGuid, @GroupGuid, @ProductGuid, @SortIndex, @NavisionFamSubFamId)");


                                command.CommandText = query.ToString();
                                command.Parameters.Add(new OleDbParameter("@GroupProductGuid", groupProductGuid));
                                command.Parameters.Add(new OleDbParameter("@GroupGuid", groupGuid));
                                command.Parameters.Add(new OleDbParameter("@ProductGuid", producto.Referencia));
                                command.Parameters.Add(new OleDbParameter("@SortIndex", sortIndex));
                                command.Parameters.Add(new OleDbParameter("@NavisionFamSubFamId", navisionFamSubFamId));
                                command.Connection = connection;

                                command.ExecuteNonQuery();
                            }
                            #endregion

                            #region Insert a ProductTable

                            using (OleDbCommand command = new OleDbCommand())
                            {
                                StringBuilder query = new StringBuilder();
                                query.Append("INSERT INTO ProductTable");
                                query.Append("(ProductGuid, ProductGrp, ItemCustomerDiscountGroup, AllowInvoiceDiscount, ");
                                query.Append("ListPrice, Description2, CdadMinMultiploVtas, Inventory, SalesUOM, Familia, ");
                                query.Append("Subfamilia, Class,  BaseUOM, PriceIncludesVAT, VATProductPostingGroup, ProductName) ");
                                query.Append("VALUES(@ProductGuid, @ProductGrp, @ItemCustomerDiscountGroup, @AllowInvoiceDiscount, ");
                                query.Append("@ListPrice, @Description2, @CdadMinMultiploVtas, @Inventory, @SalesUOM, @Familia, ");
                                query.Append("@Subfamilia, @Class, @BaseUOM, @PriceIncludesVAT, @VATProductPostingGroup, @ProductName) ");

                                command.CommandType = System.Data.CommandType.Text;
                                command.CommandText = query.ToString();
                                command.Parameters.Add(new OleDbParameter("@ProductGuid", producto.Referencia));
                                command.Parameters.Add(new OleDbParameter("@ProductGrp", "MATERIALES"));
                                command.Parameters.Add(new OleDbParameter("@ItemCustomerDiscountGroup", producto.GrupoDescuento));
                                command.Parameters.Add(new OleDbParameter("@AllowInvoiceDiscount", producto.PermiteDescuento));
                                command.Parameters.Add(new OleDbParameter("@ListPrice", producto.Precio));
                                command.Parameters.Add(new OleDbParameter("@Description2", "")); //producto.Descripcion2));
                                command.Parameters.Add(new OleDbParameter("@CdadMinMultiploVtas", producto.Multiple));
                                command.Parameters.Add(new OleDbParameter("@Inventory", producto.Stock));
                                command.Parameters.Add(new OleDbParameter("@SalesUOM", "UD"));
                                command.Parameters.Add(new OleDbParameter("@Familia", producto.Familia));
                                command.Parameters.Add(new OleDbParameter("@Subfamilia", producto.SubFamilia));
                                command.Parameters.Add(new OleDbParameter("@Class", ""));
                                command.Parameters.Add(new OleDbParameter("@BaseUOM", "UD"));
                                command.Parameters.Add(new OleDbParameter("@PriceIncludesVAT", "0"));
                                command.Parameters.Add(new OleDbParameter("@VATProductPostingGroup", "IVA21"));
                                command.Parameters.Add(new OleDbParameter("@ProductName", producto.Descripcion));
                                command.Connection = connection;

                                command.ExecuteNonQuery();
                            }
                            #endregion
                        }
                        else
                        {
                            #region Update de ProductTable

                            using (OleDbCommand command = new OleDbCommand())
                            {
                                StringBuilder query = new StringBuilder();
                                query.Append("UPDATE ProductTable ");
                                query.Append("SET inventory = @stock, ");
                                query.Append("productname = @descripcion, ");
                                query.Append("listprice = @precio ");
                                query.Append("WHERE productguid = @referencia");

                                command.CommandText = query.ToString();
                                command.Parameters.Add(new OleDbParameter("@stock", producto.Stock));
                                command.Parameters.Add(new OleDbParameter("@descripcion", producto.Descripcion));
                                //command.Parameters.Add(new OleDbParameter("@descripcion2", producto.Descripcion2));
                                command.Parameters.Add(new OleDbParameter("@precio", producto.Precio.ToString().Replace(".", ",")));
                                command.Parameters.Add(new OleDbParameter("@referencia", producto.Referencia));
                                command.Connection = connection;

                                command.ExecuteNonQuery();
                            }
                            #endregion
                        }

                        //TODO: Creación de traducciones --> Falta actualización
                        foreach (Traduccion traduccion in producto.Traducciones)
                        {
                            using (OleDbCommand command = new OleDbCommand())
                            {
                                StringBuilder query = new StringBuilder();
                                query.Append("INSERT INTO ProductTranslation(ProductGuid, LanguageGuid, ProductName) ");
                                query.Append("VALUES(@ProductGuid, @LanguageGuid, @ProductName)");

                                command.Connection = connection;
                                command.CommandText = query.ToString();
                                command.Parameters.Add(new OleDbParameter("@ProductGuid", producto.Referencia));
                                command.Parameters.Add(new OleDbParameter("@LanguageGuid", traduccion.Idioma));
                                command.Parameters.Add(new OleDbParameter("@ProductName", traduccion.Texto));

                                command.ExecuteNonQuery();
                            }
                        }
                    }
                    correcto = true;
                }
                correcto = true;
            }
            catch (Exception ex)
            {
                FileStream file = File.Open(@"\\192.168.1.202\Software\Sincronizacion\logs.txt", FileMode.OpenOrCreate);
                file.Close();

                File.WriteAllText(@"\\192.168.1.202\Software\Sincronizacion\logs.txt", ex.Message);
                correcto = false;
            }
            return correcto;
        }

        public bool EliminarProductos()
        {
            using (connection = new OleDbConnection(GetConnectionString()))
            {
                connection.Open();
                List<string> referencias = GetReferencias();
                foreach (string referencia in referencias)
                {
                    if (!ExisteNav(referencia))
                    {
                        EliminarProducto(referencia);
                        Console.WriteLine("Se ha eliminado el producto con referencia: " + referencia);
                    }
                }
            }
            return true;
        }

        public bool ActualizarTextos()
        {
            bool correcto = true;

            try
            {
                this.productos = this.GetProductos();

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    foreach (Producto producto in productos)
                    {
                        if (producto.ActualizarTextos)
                        {
                            // GET TEXTOS
                            List<ProductoCaracteristicas.ProductoCaracteristica> textos = GetTextos(producto.Referencia);



                            //delete everything
                            using (OleDbCommand command = new OleDbCommand())
                            {
                                StringBuilder query = new StringBuilder();
                                query.Append("DELETE FROM ProductoOrdenCaracteristicas ");
                                query.Append("WHERE NumProduct = @referencia; ");
                                query.Append("DELETE FROM ProductoTextoCaracteristicas ");
                                query.Append("WHERE NumProduct = @referencia");

                                command.CommandText = query.ToString();
                                command.Parameters.Add(new OleDbParameter("@referencia", producto.Referencia));

                                command.ExecuteNonQuery();
                            }



                            //insert everything
                            foreach (ProductoCaracteristicas.ProductoCaracteristica texto in textos)
                            {
                                using (OleDbCommand command = new OleDbCommand())
                                {
                                    StringBuilder query = new StringBuilder();
                                    //TODO: Tablas "ProductoOrdenCaracteristicas" y "ProductoTextoCaracteristicas"

                                    command.CommandText = query.ToString();
                                    command.Parameters.Add(new OleDbParameter("@referencia", producto.Referencia));

                                    command.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                correcto = false;
            }

            return correcto;
        }
    }
}
