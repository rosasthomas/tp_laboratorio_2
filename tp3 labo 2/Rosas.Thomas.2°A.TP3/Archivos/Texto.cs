using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto
    {
        public bool Guardar(string archivo, string datos)
        {
            bool flag = false;

            try
            {
                StreamWriter lista = new StreamWriter(archivo, true);
                lista.Write(datos);              
                lista.Close();
                flag = true;
            }
            catch (Exception e)
            {
                flag = false;
                throw new ArchivosException(e);
            }

            return flag;
        }

        public bool Leer(string archivo, out string datos)
        {
            datos = "";
            bool flag = false;

            try
            {
                StreamReader leer = new StreamReader(archivo);

                do
                {
                    datos += leer.ReadLine();
                    datos += "\n";
                } while (!leer.EndOfStream);

                leer.Close();
                flag = true;
            }
            catch (Exception)
            {
                flag = false;
                datos = "No se pudo leer el archivo txt";
            }

            return flag;
        }
    }
}
