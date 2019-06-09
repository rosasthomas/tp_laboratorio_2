using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Xml.Serialization;
using System.IO;
using Archivos;

namespace Clases_Instanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }

        public Jornada this[int i]
        {
            get
            {
                Jornada j = null;
                int index = 0;
                foreach (Jornada jornada in this.jornada)
                {
                    if (i == index)
                    {
                        j = jornada;
                    }
                    i++;
                }
                return j;
            }
            set { this.jornada[i] = value; }
        }

        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornada = new List<Jornada>();
        }

        /// <summary>
        /// Serializará los datos de la universidad en un XML, incluyendo todos los datos de sus
        /// profesores, alumnos y jornadas
        /// </summary>
        /// <param name="uni">Universidad</param>
        /// <returns>(true)si se pudo serializar (false)caso contrario</returns>
        public static bool Guardar(Universidad uni)
        {
            bool flag = false;
            Xml<Universidad> guar = new Xml<Universidad>();

            if (guar.Guardar(AppDomain.CurrentDomain.BaseDirectory + @"\Universidad.txt", uni))
            {
                flag = true;
            }

            return flag;
        }

        /// <summary>
        ///  retornará una universidad con todos los datos previamente serializados
        /// </summary>
        /// <returns>Universidad con todos los datos cargados</returns>
        public Universidad Leer()
        {
            Universidad u = new Universidad();
            Xml<Universidad> leer = new Xml<Universidad>();

            leer.Leer(AppDomain.CurrentDomain.BaseDirectory + @"\Universidad.txt", out u);

            return u;
        }

        /// <summary>
        /// Retornara todos los datos de la universidad
        /// </summary>
        /// <param name="uni">Universidad</param>
        /// <returns>Cadena con los datos</returns>
        private static string MostrarDatos(Universidad uni)
        {
            string retorno = "JORNADA:";
            foreach (Jornada jornada in uni.Jornadas)
            {
                retorno += jornada.ToString();
            }
            return retorno;
        }

        /// <summary>
        /// Devolvera los datos de la universidad
        /// </summary>
        /// <returns>Cadena con los datos</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        /// <summary>
        /// Una universidad será igual a un alumno si el mismo está inscripto en ella
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>(true)si esta inscripto (false)si no esta inscripto</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool flag = false;

            foreach (Alumno alumno in g.alumnos)
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
        /// Una universidad será distinta a un alumno si el mismo no esta inscripto en ella
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>(true)si no esta inscripto (false)si esta inscripto</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Una universidad será igual a un profesor si el mismo está dando clases en ella
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>(true)si esta dando clases (false)si no esta dando clases</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool flag = false;

            foreach (Profesor profesor in g.profesores)
            {
                if (profesor == i)
                {
                    flag = true;
                    break;
                }
            }

            return flag;
        }

        /// <summary>
        /// Una universidad será distinta a un profesor si el mismo no está dando clases en ella
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>(true)si no esta dando clases (false)si esta dando clases</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        ///  Retornará el primer profesor capaz de dar esa clase.
        ///  Sino, lanzará la Excepción SinProfesorException
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Profesor capaz de dar la clase</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor profesorRetorno = null;
            bool flag = false;

            foreach (Profesor p in u.Instructores)

            {
                if (p == clase)
                {
                    profesorRetorno = p;
                    flag = true;
                    break;
                }
            }

            if (!flag)
                throw new SinProfesorException();

            return profesorRetorno;
        }

        /// <summary>
        /// Retornará el primer profesor que no pueda dar la clase
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Profesor que no puede dar la clase</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor profesorRetorno = null;
            bool flag = false;

            foreach (Profesor p in u.Instructores)
            {
                if (p != clase)
                {
                    profesorRetorno = p;
                    flag = true;
                    break;
                }
            }

            if (!flag)
                throw new SinProfesorException();

            return profesorRetorno;
        }

        /// <summary>
        ///  Genera y agrega una nueva Jornada indicando la clase, 
        ///  un profesor que pueda darla(según su atributo ClasesDelDia) y la lista de alumnos que la toman
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Universidad con la nueva jornada</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor profesor;

            profesor = g == clase;

            Jornada nuevaJornada = new Jornada(clase, profesor);
            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno == clase)
                {
                   nuevaJornada += alumno;
                }
            }

            g.Jornadas.Add(nuevaJornada);

            return g;
        }

        /// <summary>
        /// Agregara al alumno a la universidad validando que no esté previamente
        /// cargado
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Universidad con el alumno agregado</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
                if (u != a)
                {
                    u.alumnos.Add(a);
                }
                else
                {
                    throw new AlumnoRepetidoException();
                }

            return u;
        }

        /// <summary>
        /// Agregara el profesor a la universidad validando que no esté previamente
        /// cargado
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>Universidad con el profesor agregado</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
                if (u != i)
                {
                    u.profesores.Add(i);
                }

            return u;
        }
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD,
        }
    }
}
