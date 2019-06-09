using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        public Alumno()
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Mostrara todos los datos del alumno
        /// </summary>
        /// <returns>Cadena con los datos</returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + "\nESTADO DE CUENTA: " + this.estadoCuenta + this.ParticiparEnClase();
        }

        /// <summary>
        /// Retorna las clases que el alumno toma
        /// </summary>
        /// <returns>Cadena con las clases</returns>
        protected override string ParticiparEnClase()
        {
            return "\nTOMA CLASE DE " + this.claseQueToma;
        }

        /// <summary>
        ///  Valida si un alumno es igual a una clase mientras que el alumno tome esta clase y su estado de cuenta no sea deudor
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase</param>
        /// <returns>(true) si tomas la clase (false) si no la toma</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool flag = false;

            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                flag = true;
            }

            return flag;
        }

        /// <summary>
        /// Valida si un alumno es distinto a una clase mientras que el alumno no tome esta clase
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase</param>
        /// <returns>(true) si es distinto (false) si no lo es</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            bool flag = false;

            if (a.claseQueToma != clase)
            {
                flag = true;
            }

            return flag;
        }

        /// <summary>
        /// Muestra todos los datos del alumno
        /// </summary>
        /// <returns>cadena con los datos</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado,
        }
    }   
}
