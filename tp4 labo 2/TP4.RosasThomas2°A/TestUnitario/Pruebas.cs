using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitario
{
    [TestClass]
    public class Pruebas
    {
        [TestMethod]
        public void ListaInstanciada()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
        }

        [TestMethod]
        public void CargarDosIguales()
        {
            Correo correo = new Correo();
            Paquete p1 = new Paquete("Ezeiza", "1234");
            Paquete p2 = new Paquete("Lanus", "1234");
            try
            {
                correo += p1;
                correo += p2;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(TrackingIdRepetidoException));
            }      
        }
    }
}
