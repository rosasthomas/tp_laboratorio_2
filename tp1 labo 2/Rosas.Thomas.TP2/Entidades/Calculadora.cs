using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        private static string ValidarOperador(string operador)
        {
            string auxiliar = "+";

            if (operador == "+" || operador == "-" || operador == "/" || operador == "*")
            {
                auxiliar = operador;
            }

            return auxiliar;
        }
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
