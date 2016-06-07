using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sincronización
{
    public class Pedidos : Base
    {
        public bool CrearPedido()
        {
            //TODO: Sincronizar correctamente

            //Datos del pedido
            PedidoFicha.PedidoFicha pedido = new PedidoFicha.PedidoFicha();
            pedido.Albaran_valorado = true;
            
            //Datos de las lineas
            List<PedidoFicha.Sales_Order_Line> pedidoLineas = new List<PedidoFicha.Sales_Order_Line>();

            //trato lineas
            PedidoFicha.Sales_Order_Line pedidoLinea = new PedidoFicha.Sales_Order_Line();
            pedidoLineas.Add(pedidoLinea);


            //vinculo
            pedido.SalesLines = pedidoLineas.ToArray();

            PedidoFicha.PedidoFicha_Service servPedido = new PedidoFicha.PedidoFicha_Service();
            servPedido.Credentials = GetNetworkCredential();
            //servPedido.Url = "http://192.168.1.202:7047/InstanceName/WS/MAI%20AUTOPARTS%2C%20S.L./Page/PedidoFicha";
            servPedido.Create(ref pedido);

            return true;
        }
    }
}
