using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        /// <summary>
        /// Instanciara los atributos
        /// </summary>
        static PaqueteDAO()
        {
            conexion = new SqlConnection(Properties.Settings.Default.correo);
            comando = new SqlCommand();
        }

        /// <summary>
        ///  Guarda los datos de un paquete en la base de datos 
        /// </summary>
        /// <param name="p"></param>
        /// <returns>(true)Si pudo guardarse (false)Si no se pudo guardar</returns>
        public static bool Insertar(Paquete p)
        {
            bool flag = false;
            
            try
            {
                comando.CommandType = CommandType.Text;
                comando.CommandText = "INSERT INTO [correo-sp-2017].dbo.Paquetes (direccionEntrega, trackingID, alumno) values" +
                                      "('" + p.DireccionEntrega + "', '" + p.TrackingID + "', 'Rosas')";
                conexion.Open();
                comando.Connection = conexion;
                if (comando.ExecuteNonQuery() > 0)
                {
                    flag = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conexion.Close();
            }

            //throw new FormatException("Error gato");
            return flag;
        }

    }
}
