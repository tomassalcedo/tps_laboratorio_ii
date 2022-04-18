using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        //constructor por defecto que inicializa la variable numero en 0
        public Operando()
        {
            numero = 0;
        }

        public Operando(double numero)
        {
            this.numero = numero;
        }

        public Operando(string numero)
        {
            if(Double.TryParse(numero,out _))
            {
               this.numero = Convert.ToDouble(numero);
            }
            else
            {
                this.numero = 0;
            }
        }

        //Convierte string pasado a double si se pudo, sino retorna 0
        private double ValidarOperando(string strNumero)
        {
            double auxiliar;

            if(!double.TryParse(strNumero,out auxiliar))
            {
                auxiliar = 0;
            }

            return auxiliar;
        }



        //Setea valor del numero
        public string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }   
        }

        private bool EsBinario(string binario)
        {
            bool auxiliar = false;

            for(int i = 0; i < binario.Length; i++)
            {
                if(binario[i] != '0' && binario[i] != '1')
                {
                    return auxiliar;
                }    
            }
            auxiliar = true;
            return auxiliar;
        }

        public string BinarioDecimal(string binario)
        {
            if(EsBinario(binario) && binario.Trim() != "0")
            {
                return Convert.ToString(Convert.ToInt32(binario, 2), 10);
            }
            return "Valor invalido";
        }

        public string DecimalBinario(double numero)
        { 
            if(numero > 0 && !EsBinario(numero.ToString()))
            {
                int numEnteroPos = Convert.ToInt32(numero);
                return Convert.ToString(numEnteroPos, 2);
            }
            return "Valor invalido";
        }

        public string DecimalBinario(string numero)
        {
            if(double.TryParse(numero, out double num) && !EsBinario(numero))
            {
                if(num > 0)
                {
                    return DecimalBinario(num);
                }
            }
            return "Valor invalido";
        }

        public static double operator -(Operando num1,Operando num2)
        {
            return num1.numero - num2.numero;
        }

        public static double operator +(Operando num1,Operando num2)
        {
            return num1.numero + num2.numero;
        }

        public static double operator /(Operando num1,Operando num2)
        {
            if(num2.numero == 0)
            {
                return double.MinValue;
            }
            return num1.numero / num2.numero;
        }

        public static double operator *(Operando num1, Operando num2)
        {
            return num1.numero * num2.numero;
        }
    }
}
