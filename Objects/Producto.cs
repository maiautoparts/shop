using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class Traduccion
    {
        private string idioma;
        private string texto;

        public string Idioma { get; set; }
        public string Texto { get; set; }
    }
    public class Producto
    {
        private string referencia;
        private string descripcion;
        private string descripcion2;
        private decimal precio;
        private int stock;
        private int multiple;
        private string imagen;
        private bool productoWeb;
        private bool paraSubir;
        private int familia;
        private int subfamilia;
        private int permiteDescuento;
        private int grupoDescuento;
        private List<Traduccion> traducciones;
        private bool actualizarTextos;

        public string Referencia { get; set; }
        public string Descripcion { get; set; }
        public string Descripcion2 { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int Multiple { get; set; }
        public string Imagen { get; set; }
        public bool ProductoWeb { get; set; }
        public bool ParaSubir { get; set; }
        public int Familia { get; set; }
        public int SubFamilia { get; set; }
        public int PermiteDescuento { get; set; }
        public int GrupoDescuento { get; set; }
        public List<Traduccion> Traducciones { get; set; }
        public bool ActualizarTextos { get; set; }
    }
}
