using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Analiza si el operador recibido es válido
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>operador validado</returns>
        private static string ValidarOperador(string operador)
        {
            string auxiliar = "+";

            if (operador == "+" || operador == "-" || operador == "/" || operador == "*")
            {
                auxiliar = operador;
            }

            return auxiliar;
        }

        /// <summary>
        /// Realiza la operacion deseada entre los numeros recibidos
        /// </summary>
        /// <param name="numUno"></param>
        /// <param name="numDos"></param>
        /// <param name="operador"></param>
        /// <returns>resultado de la operacion</returns>
        public static double Operar(Numero numUno, Numero numDos, string operador)
        {
            double retorno;
            
            switch (ValidarOperador(operador))
            {
                case "+":
                    retorno = numUno + numDos;
                        break;
                case "-":
                    retorno = numUno - numDos;
                    break;
                case "*":
                    retorno = numUno * numDos;
                    break;
                case "/":
                    retorno = 0;
                    if (!Equals(numDos, 0))
                        retorno = numUno / numDos;
                    if (double.IsInfinity(retorno))
                        retorno = double.MinValue;
                    break;
                default:
                    retorno = 0;
                    break;
            }
            return retorno;
        }
    }
}
