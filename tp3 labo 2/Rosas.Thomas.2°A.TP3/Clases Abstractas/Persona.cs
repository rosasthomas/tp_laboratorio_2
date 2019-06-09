using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;

        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = this.ValidarNombreApellido(value); }
        }

        public int DNI
        {
            get { return this.dni; }
            set { this.dni = this.ValidarDni(this.Nacionalidad, value); }
        }
        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = this.ValidarNombreApellido(value); }
        }
        public string StringToDNI
        {
            set { this.DNI = ValidarDni(this.nacionalidad, value); }
        }

        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// Muestra los datos de la persona
        /// </summary>
        /// <returns>Cadena con los datos</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("NOMBRE COMPLETO: {1}, {0}", this.Nombre, this.Apellido);
            sb.AppendLine("");
            sb.AppendLine("NACIONALIDAD: " + this.Nacionalidad);
            return sb.ToString();
        }

        /// <summary>
        /// Llama a la funcion ValidarDni(ENacionalidad nacionalidad, string dato) para validar el numero recibido
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">DNI a validar</param>
        /// <returns>El DNi en formato int</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            return this.ValidarDni(nacionalidad, dato.ToString());
        }

        /// <summary>
        ///  valida que el DNI sea correcto, teniendo en cuenta su nacionalidad. Argentino entre 1 y
        ///89999999 y Extranjero entre 90000000 y 99999999. Caso contrario, se lanzará la excepción
        ///NacionalidadInvalidaException, o si el presenta un error de formato  se lanzará DniInvalidoException
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">Numero de DNI de la persona</param>
        /// <returns>Retorna el numero de DNI en formarto int</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        { 
            int auxiliar;
            bool flag = false;
            
                if (dato.Length <= 8 && dato.Length >= 1 && int.TryParse(dato, out auxiliar))
                {
                    if (nacionalidad == ENacionalidad.Argentino && auxiliar > 0 && auxiliar < 90000000)
                    {
                        flag = true;
                    }
                    else if (nacionalidad == ENacionalidad.Extranjero && auxiliar > 89999999 && auxiliar < 100000000)
                    {
                        flag = true;
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                    }
                }
                else
                {
                    throw new DniInvalidoException("El dni no tiene el formato correcto");
                }    

            if (flag == false)
                auxiliar = 0;

            return auxiliar;
        }

        /// <summary>
        /// Validará que las cadenas contengan caracteres válidos para nombres o apellidos. Caso contrario, no se
        ///cargará.
        /// </summary>
        /// <param name="dato">Nombre o apellido a validar</param>
        /// <returns>Nombre validado o una cadena vacia si no cumple los requisitos</returns>
        private string ValidarNombreApellido(string dato)
        {
            bool flag = false;

            foreach (char c in dato)
            {
                if (!char.IsLetter(c))
                {
                    flag = true;
                    break;
                }
            }

            if (flag)
            {
                dato = "";
            }

            return dato;
        }
        public enum ENacionalidad
        {
            Argentino,
            Extranjero,
        }
    }
}
