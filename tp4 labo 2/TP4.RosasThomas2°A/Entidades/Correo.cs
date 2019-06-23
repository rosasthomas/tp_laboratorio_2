using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        /// <summary>
        /// Propiedad de la lista de paquetes
        /// </summary>
        public List<Paquete> Paquetes
        {
            get { return this.paquetes; }
            set { this.paquetes = value; }
        }

        /// <summary>
        /// Instanciara los atributos mockPaquetes y paquetes
        /// </summary>
        public Correo()
        {
            mockPaquetes = new List<Thread>();
            paquetes = new List<Paquete>();
        }

        /// <summary>
        /// Cerrará todos los hilos activos
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread thread in this.mockPaquetes)
            {
                try
                {
                    thread.Abort();           
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        /// <summary>
        /// Retornara los datos de todos los paquetes de la lista
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>Cadena con los datos</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            string retorno = "";

            foreach (Paquete p in this.paquetes)
            {
                retorno += string.Format("{0} para {1} ({2})\n", p.TrackingID, p.DireccionEntrega, p.Estado.ToString());
            }
            return retorno;
        }

        /// <summary>
        /// Añadirá un paquete al correo
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns>Correo con el paquete agregado</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            bool flag = false;

            foreach (Paquete paquete in c.paquetes)
            {
                if (p == paquete)
                {
                    flag = true;
                    throw new TrackingIdRepetidoException("El paquete ya se encuentra en el correo");                  
                }
                else
                {
                    flag = false;                  
                }
                
            }

            if (!flag)
            {
                c.paquetes.Add(p);
                Thread hilo = null;

                try
                {
                    hilo = new Thread(p.MockCicloDeVida);          
                    c.mockPaquetes.Add(hilo);
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    hilo.Start();
                }         
            }

            return c;
        }
    }
}
