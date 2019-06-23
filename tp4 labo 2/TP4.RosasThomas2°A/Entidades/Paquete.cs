using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        public event DelegadoEstado InformaEstado;

        /// <summary>
        /// Propiedad del atributo direccionEntrega
        /// </summary>
        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; }
        }

        /// <summary>
        /// Propiedad del atributo TrackingID
        /// </summary>
        public string TrackingID
        {
            get { return this.trackingID; }
            set { this.trackingID = value; }
        }

        /// <summary>
        /// Propiedad del atributo Estado
        /// </summary>
        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

        /// <summary>
        /// Instanciara los atributos direccionEntrega y trackingID
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
        }

        /// <summary>
        /// Retornará una cadena con la información del paquete
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>cadena con información</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        { 
            return string.Format("{0} para {1}", this.trackingID, this.direccionEntrega);
        }

        /// <summary>
        /// Devuelve la información completa del paquete
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Un paquete será igual a otro siempre y cuando su trackingID sea el mismo
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>(true)Si son iguales (false)Caso contrario</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool flag = false;

            if (p1.TrackingID == p2.TrackingID)
            {
                flag = true;
            }

            return flag;
        }

        /// <summary>
        ///  Un paquete será distinto a otro siempre y cuando su trackingID no sea el mismo
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>(true)Si son distintos (false)Caso contrario</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Cambia el estado del paquete y guarda los datos del paquete en la base de datos
        /// </summary>
        public void MockCicloDeVida()
        {
            
            try
            {
                while (this.Estado != EEstado.Entregado)
                {
                    Thread.Sleep(4000);
                    if (this.Estado == EEstado.Ingresado)
                    {
                        this.Estado = EEstado.EnViaje;
                    }
                    else if (this.Estado == EEstado.EnViaje)
                    {
                        this.Estado = EEstado.Entregado;
                    }
                    else if (this.estado == EEstado.Entregado)
                    {
                        this.Estado = EEstado.Ingresado;
                    }

                    this.InformaEstado(this, new EventArgs());
                }
                PaqueteDAO.Insertar(this);
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado,
        }

        public delegate void DelegadoEstado(object sender, EventArgs e);
    }
}
