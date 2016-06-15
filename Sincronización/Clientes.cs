using Objects;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sincronización
{
    public class Clientes : Base
    {
        private List<Cliente> clientes;
        private string connectionString = GetConnectionString();


        public bool ActualizarFacturas()
        {
            bool correcto = true;

            try
            {
                List<FacturasLista.FacturasLista_Filter> filters = new List<FacturasLista.FacturasLista_Filter>();

                string ultimaActualizacion = GetLastLedgerUpdate().ToUniversalTime().ToString("MMddyyyy");

                FacturasLista.FacturasLista_Filter filter1 = new FacturasLista.FacturasLista_Filter();
                filter1.Field = FacturasLista.FacturasLista_Fields.Posting_Date;
                filter1.Criteria = ">" + ultimaActualizacion;
                filters.Add(filter1);

                FacturasLista.FacturasLista_Filter filter2 = new FacturasLista.FacturasLista_Filter();
                filter2.Field = FacturasLista.FacturasLista_Fields.Document_Type;
                filter2.Criteria = "2|3";
                filters.Add(filter2);

                FacturasLista.FacturasLista_Service facturasService = new FacturasLista.FacturasLista_Service();
                facturasService.Url = "http://192.168.1.202:7047/InstanceName/WS/MAI%20AUTOPARTS%2C%20S.L./Page/FacturasLista";
                facturasService.Credentials = GetNetworkCredential();
                FacturasLista.FacturasLista[] facturasLista = facturasService.ReadMultiple(filters.ToArray(), null, 0);


                foreach (FacturasLista.FacturasLista factura in facturasLista)
                {
                    InsertInvoice(factura);
                }
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


        public bool ActualizarPrecios()
        {
            bool correcto = true;
            List<Cliente> clientes = GetClientes();
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    foreach (Cliente cliente in clientes)
                    {
                        using (OleDbCommand command = new OleDbCommand())
                        {
                            //TODO: Rellenar con datos reales
                            StringBuilder query = new StringBuilder();
                            query.Append("UPDATE CustomerTable ");
                            query.Append("SET PriceGroupCode = @priceGroupCode ");
                            query.Append(", CustomerDiscountGroup = @discountGroup ");
                            query.Append("WHERE CustomerGuid = @clienteNo");

                            command.CommandText = query.ToString();
                            command.Parameters.Add(new OleDbParameter("@priceGroupCode", cliente.GrupoNetos));
                            command.Parameters.Add(new OleDbParameter("@discountGroup", cliente.GrupoDescuentos));
                            command.Parameters.Add(new OleDbParameter("@clienteNo", cliente.ClienteNo));
                            command.Connection = connection;

                            command.ExecuteNonQuery();
                        }
                    }
                }
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

        private List<Cliente> GetClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            ClienteLista.ClienteLista_Service clientesService = new ClienteLista.ClienteLista_Service();
            clientesService.Url = "http://192.168.1.202:7047/InstanceName/WS/MAI%20AUTOPARTS%2C%20S.L./Page/ClienteLista";
            clientesService.Credentials = GetNetworkCredential();
            ClienteLista.ClienteLista[] clientesServ = clientesService.ReadMultiple(null, null, 0) ;

            foreach (ClienteLista.ClienteLista clienteS in clientesServ)
            {
                Cliente cliente = new Cliente();
                cliente.ClienteNo = clienteS.No;

                cliente.GrupoDescuentos = clienteS.Customer_Disc_Group;
                if (cliente.GrupoDescuentos == null)
                    cliente.GrupoDescuentos = "";

                cliente.GrupoNetos = clienteS.Customer_Price_Group;
                if (cliente.GrupoNetos == null)
                    cliente.GrupoNetos = "";

                clientes.Add(cliente);
            }

            return clientes;
        }

        private void InsertInvoice(FacturasLista.FacturasLista factura)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand command = new OleDbCommand())
                {
                    StringBuilder query = new StringBuilder();
                    query.Append("INSERT INTO CustomerLedgerEntry ");
                    query.Append("(Amount, RemainingAmount, OriginalAmountLCY, RemainingAmountLCY, ");
                    query.Append("AmountLCY, SalesLCY, ProfitLCY, InvoiceDiscountLCY, SellToCustomerGuid, CustomerGuid, ");
                    query.Append("IsOpen, DueDate, PostingDate, DocumentType, DocumentGuid, DocumentDate, ExternalDocumentNo, Description) ");

                    query.Append("VALUES(@amount, @remainingAmount, @originalAmount, @remainingAmountLCY, ");
                    query.Append("@amountLCY, @salesLCY, @profitLCY, @invoiceDiscountLCY, @sellToCustomerGuid, @customerGuid, ");
                    query.Append("@isOpen, @dueDate, @postingDate, @documentType, @documentGuid, @documentDate, @externalDocumentNo, @description)");

                    command.CommandText = query.ToString();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;

                    //command.Parameters.Add(new OleDbParameter("@entryGuid",))
                    command.Parameters.Add(new OleDbParameter("@amount", factura.Amount));
                    command.Parameters.Add(new OleDbParameter("@remainingAmount", factura.Remaining_Amount));
                    command.Parameters.Add(new OleDbParameter("@originalAmount", factura.Original_Amount));
                    command.Parameters.Add(new OleDbParameter("@remainingAmountLCY", factura.Remaining_Amt_LCY));
                    command.Parameters.Add(new OleDbParameter("@amountLCY", factura.Amount_LCY));
                    command.Parameters.Add(new OleDbParameter("@salesLCY", "0"));
                    command.Parameters.Add(new OleDbParameter("@profitLCY", "0"));
                    command.Parameters.Add(new OleDbParameter("@invoiceDiscountLCY", "0"));
                    command.Parameters.Add(new OleDbParameter("@sellToCustomerGuid", factura.Customer_No));
                    command.Parameters.Add(new OleDbParameter("@customerGuid", factura.Customer_No));
                    command.Parameters.Add(new OleDbParameter("@isOpen", "0"));
                    command.Parameters.Add(new OleDbParameter("@dueDate", factura.Due_Date));
                    command.Parameters.Add(new OleDbParameter("@postingDate", factura.Posting_Date));
                    command.Parameters.Add(new OleDbParameter("@documentType", factura.Document_Type));
                    command.Parameters.Add(new OleDbParameter("@documentGuid", factura.Document_No));
                    command.Parameters.Add(new OleDbParameter("@documentDate", factura.Posting_Date));
                    command.Parameters.Add(new OleDbParameter("@externalDocumentNo", ""));
                    command.Parameters.Add(new OleDbParameter("@description", factura.Description));

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private DateTime GetLastLedgerUpdate()
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand command = new OleDbCommand())
                {
                    StringBuilder query = new StringBuilder();
                    query.Append("SELECT TOP 1 PostingDate ");
                    query.Append("FROM CustomerLedgerEntry ");
                    query.Append("ORDER BY PostingDate DESC");

                    command.Connection = connection;
                    command.CommandText = query.ToString();
                    connection.Open();

                    return (DateTime)command.ExecuteScalar();
                }
            }
        }
    }
}
