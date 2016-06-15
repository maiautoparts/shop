using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class Pedido
    {
        public string NumeroExterno { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaRequerida { get; set; }
        public DateTime FechaEnvio { get; set; }
        public Decimal Importe { get; set; }
        public List<PedidoLinea> Lineas { get; set; }
    }
}
