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

        public Numero() :this(0)
        {

        }

        public Numero(double auxNumero)
        {
            numero = auxNumero;
        }
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        private double ValidarNumero(string strNumero)
        {            
            if (!double.TryParse(strNumero, out double auxiliar))
            {
                auxiliar = 0;
            }

            return auxiliar;
        }

        private string SetNumero
        {
            set
            {
               this.numero = ValidarNumero(value);
            }
        }

        public string BinarioDecimal(string binario)
        {
            string decimalNum = "Valor inválido";

            if (binario == double.MinValue.ToString() || int.Parse(binario) < 0 || int.Parse(binario) > 1)
            {
              decimalNum = binario;
            }
            else if(binario != decimalNum && binario != "" && int.Parse(binario) >= 0 && int.Parse(binario) <= 1)
            {
                decimalNum = Convert.ToInt32(binario,2).ToString();
            }
             
                      
            return decimalNum;
        }
        public string DecimalBinario(string numero)
        {
            string retorno = "Valor inválido";
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
        public string DecimalBinario(double numero)
        {
            return DecimalBinario(numero.ToString());
        }

        public static double operator +(Numero numeroUno, Numero numeroDos)
        {
            return numeroUno.numero + numeroDos.numero;
        }
        public static double operator -(Numero numeroUno, Numero numeroDos)
        {
            return numeroUno.numero - numeroDos.numero;
        }
        public static double operator *(Numero numeroUno, Numero numeroDos)
        {
            return numeroUno.numero * numeroDos.numero;
        }
        public static double operator /(Numero numeroUno, Numero numeroDos)
        {
            return numeroUno.numero / numeroDos.numero;
        }
    }
}
