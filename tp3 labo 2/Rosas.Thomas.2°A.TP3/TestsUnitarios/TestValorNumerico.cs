using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;

namespace TestsUnitarios
{
    [TestClass]
    public class TestValorNumerico
    {
        [TestMethod]
        public void TestNumerico()
        {
            Alumno alumno = new Alumno(2, "Jose", "Perez", "45738475", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion);
            Assert.IsInstanceOfType(alumno.DNI, typeof(int));
        }
    }
}
