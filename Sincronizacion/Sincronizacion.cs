using Sincronización;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sincronizacion
{
    class Sincronizacion
    {
        static void Main(string[] args)
        {
            bool todoCorrecto = true;
            Console.WriteLine("Sincronizando facturas...");
            bool sincroFacturas = ActualizarFacturas();
            if (sincroFacturas)
                Console.WriteLine("Facturas sincronizadas.");
            Console.WriteLine("");

            Console.WriteLine("Sincronizando productos...");
            bool sincroProductos = SincronizarProductos();
            if (sincroProductos)
                Console.WriteLine("Productos sincronizados.");
            Console.WriteLine("");

            Console.WriteLine("Sincronizando clientes...");
            bool sincroClientes = SincronizarClientes();
            if (sincroClientes)
                Console.WriteLine("Sincronizado corectamente.");
            Console.WriteLine("");


            bool sincroPedidos = SincronizarPedidos();


            Console.WriteLine("");
            if (!sincroPedidos)
            {
                todoCorrecto = false;
                Console.WriteLine("Sincronización de los pedidos fallida.");
            }

            if (!sincroProductos)
            {
                todoCorrecto = false;
                Console.WriteLine("Sincronización de los productos fallida.");
            }

            if (!sincroFacturas)
            {
                todoCorrecto = false;
                Console.WriteLine("Sincronización de las facturas fallida.");
            }

            if (!sincroClientes)
            {
                todoCorrecto = false;
                Console.WriteLine("Sincronización de los clientes fallida.");
            }

            Console.WriteLine("");
            if (todoCorrecto)
                Console.WriteLine("Todas las sincronizaciones se han realizado correctamente");

            Console.WriteLine("Pulse una tecla para continuar...");
            Console.ReadKey();
        }

        private static bool SincronizarProductos()
        {
            Productos productos = new Productos();
            return productos.SincroProductos();
        }

        private static bool ActualizarFacturas()
        {
            Clientes clientes = new Clientes();
            return clientes.ActualizarFacturas();
        }

        private static bool SincronizarPedidos()
        {
            Pedidos pedidos = new Pedidos();
            //return pedidos.CrearPedido();
            return true;
        }

        private static bool SincronizarClientes()
        {
            //TODO: Hacer que sincronice todo, de momento solo grupo de precios
            Clientes clientes = new Clientes();
            return clientes.ActualizarPrecios();
        }
    }
}