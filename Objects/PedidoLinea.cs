using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class PedidoLinea
    {
        public string Referencia { get; set; }
        public int Cantidad { get; set; }
        public decimal Descuento { get; set; }
        public decimal Importe { get; set; }
        public decimal Total { get; set; }
    }
}
