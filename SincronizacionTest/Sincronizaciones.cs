using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sincronización;

namespace SincronizacionTest
{
    [TestClass]
    public class Sincronizaciones
    {
        [TestMethod]
        public void TextosTest()
        {
            Productos productos = new Productos();
            productos.ActualizarTextos();
        }

        [TestMethod]
        public void ClientesTest()
        {

        }

        [TestMethod]
        public void PedidosTest()
        {

        }
    }
}
