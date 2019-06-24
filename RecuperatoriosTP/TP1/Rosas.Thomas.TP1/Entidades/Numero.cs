using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Constructor por defecto que inicializa los valores en 0
        /// </summary>
        public Numero() :this(0)
        {

        }

        /// <summary>
        /// Inicializará el valor con el numero pasado por parametros
        /// </summary>
        /// <param name="auxNumero"></param>
        public Numero(double auxNumero):this(auxNumero.ToString())
        {

        }

        /// <summary>
        /// Inicializará el valor con el numero pasado por parametros
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        /// <summary>
        /// Valida que la cadena contenga solo numeros
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns> nuumero en formato double</returns>
        private double ValidarNumero(string strNumero)
        {            
            if (!double.TryParse(strNumero, out double auxiliar))
            {
                auxiliar = 0;
            }

            return auxiliar;
        }

        /// <summary>
        /// Propiedad que settea al atributo numero validando que sus caracteres sean solo numericos
        /// </summary>
        private string SetNumero
        {
            set
            {
               this.numero = ValidarNumero(value);
            }
        }

        /// <summary>
        /// Convierte el valor pasado en decimal
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>numero en decimal</returns>
        public string BinarioDecimal(string binario)
        {
            string decimalNum = "Valor inválido";

            if (binario == double.MinValue.ToString())
            {
                decimalNum = binario;
            }
            else if (binario != decimalNum && binario != "")
            {
                char[] arrayString = binario.ToCharArray();

                for (int i = 0; i < arrayString.Length; i++)
                {
                    if (arrayString[i] == '1' || arrayString[i] == '0')
                    {
                        decimalNum += arrayString[i];
                    }
                    else
                    {
                        decimalNum = "Valor inválido";
                        break;
                    }
                }

                if (decimalNum != "Valor inválido")
                {
                    decimalNum = Convert.ToInt32(binario, 2).ToString();
                }
            }

            return decimalNum;
        }

        /// <summary>
        /// Convertira el valor ingresado en binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>numero en binario</returns>
        public string DecimalBinario(string numero)
        {
            string retorno = "";
            if (numero != "Valor inválido" && numero != "" && numero != double.MinValue.ToString())
            {
                int auxNumero = Convert.ToInt32(numero);
                if (auxNumero > 0)
                {
                    while (auxNumero > 0)
                    {
                        if (auxNumero % 2 == 0)
                        {
                            retorno = "0" + retorno;
                        }
                        else
                        {
                            retorno = "1" + retorno;
                        }
                        auxNumero = (int)(auxNumero / 2);
                    }
                }
                else
                {
                    if (auxNumero == 0)
                    {
                        retorno = "0";
                    }
                    else
                    {
                        retorno = "Valor inválido";
                    }
                }
            }
            return retorno;
        }

        /// <summary>
        /// Convertira el valor ingresado en binario
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>numero en binario</returns>
        public string DecimalBinario(double numero)
        {
            return DecimalBinario(numero.ToString());
        }

        /// <summary>
        /// Sumara los dos numeros
        /// </summary>
        /// <param name="numeroUno"></param>
        /// <param name="numeroDos"></param>
        /// <returns>resultado de la suma</returns>
        public static double operator +(Numero numeroUno, Numero numeroDos)
        {
            return numeroUno.numero + numeroDos.numero;
        }
        /// <summary>
        /// restara dos numeros
        /// </summary>
        /// <param name="numeroUno"></param>
        /// <param name="numeroDos"></param>
        /// <returns>resultado de la resta</returns>
        public static double operator -(Numero numeroUno, Numero numeroDos)
        {
            return numeroUno.numero - numeroDos.numero;
        }
        /// <summary>
        /// multiplicara dos numeros
        /// </summary>
        /// <param name="numeroUno"></param>
        /// <param name="numeroDos"></param>
        /// <returns>resultado de la multiplicacion</returns>
        public static double operator *(Numero numeroUno, Numero numeroDos)
        {
            return numeroUno.numero * numeroDos.numero;
        }
        /// <summary>
        /// divide dos numeros
        /// </summary>
        /// <param name="numeroUno"></param>
        /// <param name="numeroDos"></param>
        /// <returns>resultado de la division</returns>
        public static double operator /(Numero numeroUno, Numero numeroDos)
        {
            return numeroUno.numero / numeroDos.numero;
        }
    }
}
