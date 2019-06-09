using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        static Profesor()
        {
            random = new Random();
        }

        public Profesor()
        {

        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        /// <summary>
        /// Le asignara dos clases aleatorias al profesor
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                clasesDelDia.Enqueue((Universidad.EClases)random.Next(4));
            }
        }

        /// <summary>
        /// Mostrara todos los datos del profesor
        /// </summary>
        /// <returns>Cadena con los datos</returns>
        protected override string MostrarDatos()
        {
            string retorno = "";

            retorno += base.MostrarDatos();
            retorno += this.ParticiparEnClase();


            return retorno;
        }

        /// <summary>
        /// Retornara las clases que el profesor tenga en el dia
        /// </summary>
        /// <returns>Cadena con los clases</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DIA: ");

            foreach (Universidad.EClases clases in clasesDelDia)
            {
                sb.AppendLine(clases.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Un profesor sera igual a una clase sólo si da esa clase
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">Clase</param>
        /// <returns>(true) si la da (false) si no la da</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool flag = false;

            foreach (Universidad.EClases c in i.clasesDelDia)
            {
                if (c == clase)
                {
                    flag = true;
                    break;
                }
            }

            return flag;
        }

        /// <summary>
        /// Un profesor sera distinto a una clase sólo si no da esa clase
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">Clase</param>
        /// <returns>(true) si no la da (false) si la da</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        /// <summary>
        /// Mostrara los datos del profesor
        /// </summary>
        /// <returns>Cadena con los datos</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
