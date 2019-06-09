using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }

        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }

        private Jornada()
        {
            alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        /// <summary>
        /// Retornara los datos de la jornada leyendolos desde el archivo de texto
        /// </summary>
        /// <returns>Cadena con los datos de la jornada</returns>
        public static string Leer()
        {
            Texto leer = new Texto();
            string retorno;
            leer.Leer(AppDomain.CurrentDomain.BaseDirectory + @"\Jornada.txt", out retorno);
            return retorno;
        }

        /// <summary>
        /// Mostrara todos los datos de la jornada
        /// </summary>
        /// <returns>Cadena con los datos</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("");
            sb.AppendFormat("CLASE DE {0} POR {1} ", this.Clase, this.Instructor.ToString());
            sb.AppendLine("");
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno alumno in this.Alumnos)
            {
                sb.AppendLine(alumno.ToString());
            }

            sb.AppendLine("<------------------------------------------------------------------------------->");
            return sb.ToString();
        }

        /// <summary>
        /// Una jornada será igual a un alumno si el mismo participa de la clase
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>(true)si participia (false) si no participa</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool flag = false;

            foreach (Alumno alumno in j.alumnos)
            {
                if (alumno == a)
                {
                    flag = true;
                    break;
                }
            }

            return flag;
        }

        /// <summary>
        /// Un jornada será distinta a un alumno si el mismo no participa de la clase
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>(true)si no aprticipa (false)si participa</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agregara al alumno a al jornada sólo si no está previamente cargado
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>Si se pudo agregar el alumno, retornara la jornada con ese alumno agregado, sino la retornara sin él</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException(); 
            }

            return j;
        }

        /// <summary>
        /// Guardará los datos dela jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada"> Jornada a guardar</param>
        /// <returns>(true)si pudo guardarse (false)caso contrario</returns>
        public static bool Guardar(Jornada jornada)
        {
            bool flag = false;

            try
            {
                Texto guardar = new Texto();
                guardar.Guardar(AppDomain.CurrentDomain.BaseDirectory + @"\Jornada.txt", jornada.ToString());
                flag = true;
            }
            catch (Exception)
            {
                flag = false;
            }

            return flag;
        }
    }
}
