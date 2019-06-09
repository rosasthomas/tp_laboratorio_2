using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
using Excepciones;

namespace TestsUnitarios
{
    [TestClass]
    public class TestException
    {
        [TestMethod]
        public void TestDNIInvalido()
        {
            try
            {
                Alumno alum = new Alumno(1, "Juan", "Perez", "42584aaaaa", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException)); 
            }          
        }

        [TestMethod]
        public void TestNacionalidadInvalida()
        {
            try
            {
                Alumno alum = new Alumno(1, "Juan", "Perez", "94253740", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }

        [TestMethod]
        public void TestAlumnoRepetido()
        {
            try
            {
                Alumno alumno1 = new Alumno(2, "Oscar", "Palacios", "30486249", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.SPD);
                Profesor profesor = new Profesor(1, "Mario", "Perez", "92834712", EntidadesAbstractas.Persona.ENacionalidad.Extranjero);
                Alumno alumno2 = new Alumno(2, "Oscar", "Palacios", "30486249", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.SPD);
                Jornada jornada = new Jornada(Universidad.EClases.SPD, profesor);

                jornada += alumno1;
                jornada += alumno2;
            }
            catch (Exception e)
            {

                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }
    }
}
