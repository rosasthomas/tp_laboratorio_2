using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Serializa los datos que se le pasen
        /// </summary>
        /// <param name="archivo">lugar donde creara el archivo</param>
        /// <param name="datos">datos a ser guardados</param>
        /// <returns>(true)si se pudo serializar (false) caso contrario</returns>
        public bool Guardar(string archivo, T datos)
        {
            bool flag = false;

            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                StreamWriter sw = new StreamWriter(archivo);
                ser.Serialize(sw, datos);
                sw.Close();
                flag = true;
            }
            catch (Exception e)
            {
                flag = false;
                throw new ArchivosException(e);
            }

            return flag;
        }

        /// <summary>
        /// Leera los datos previamente serializados y los guardara en un objeto
        /// </summary>
        /// <param name="archivos">Lugar donde se encuetra el archivo</param>
        /// <param name="datos">objeto a ser cargado con los datos</param>
        /// <returns>(true)si se pudo leer (false)caso contrario</returns>
        public bool Leer(string archivos, out T datos)
        {
            bool flag = false;
            datos = default(T);

            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                StreamReader sr = new StreamReader(archivos);

                datos = (T)ser.Deserialize(sr);

                sr.Close();
                flag = true;
            }
            catch (Exception e)
            {
                flag = false;
                throw new ArchivosException(e);
            }

            return flag;
        }
    }
}
