using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private string mensajeBase;
        public DniInvalidoException() : base("El dni no tiene el formato correcto")
        {
            
        }

        public DniInvalidoException(Exception e) : base(e.Message)
        {

        }
        public DniInvalidoException(string mensaje) : base(mensaje)
        {
           
        }

        public DniInvalidoException(string mensaje, Exception e) : base(mensaje, e.InnerException)
        {

        }
    }
}
