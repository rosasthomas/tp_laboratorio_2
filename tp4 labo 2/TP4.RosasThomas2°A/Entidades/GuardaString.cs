using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Guarda en un archivo de texto ubicado en el escritorio los datos recibidos
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns>(true)Si se logró guardar (false) si no se pudo guardar</returns>
        public static bool Guardar(this string texto, string archivo)
        {
            bool flag = false;
            StreamWriter writer = null;

            try
            {
                writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + archivo, true);
                writer.WriteLine(texto);
                flag = true;
            }
            catch (Exception)
            {
                flag = false;
            }
            finally
            {
                if (flag)
                {
                    writer.Close();
                }
            }

            return flag;
        }
    }
}
