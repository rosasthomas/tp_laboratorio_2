using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;

namespace TestsUnitarios
{
    [TestClass]
    public class TestAtributoNulo
    {
        [TestMethod]
        public void TestNulo()
        {
            Profesor profesor = new Profesor(1, "Carlos", "Martinez", "43857463", EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            Assert.IsNotNull(profesor);
        }
    }
}
