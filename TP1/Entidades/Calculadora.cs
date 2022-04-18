using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        //Valida char operador, si no es ninguno de los puestos , retornara +
        private static char ValidarOperador(char operador)
        {
            char operadorValido;

            if (operador == '-' || operador == '+' || operador == '*' || operador == '/')
            {
                operadorValido = operador;
            }
            else
            {
                operadorValido = '+';
            }
            return operadorValido;
        }

        public static double Operar(Operando num1, Operando num2, char operador)
        {
            char auxOperador = ValidarOperador(operador);
            double resultado = 0;

            switch(auxOperador)
            {
                case '-':
                    resultado = num1 - num2;
                    break;

                case '+':
                    resultado = num1 + num2;
                    break;

                case '/':
                    resultado = num1 / num2;
                    break;

                case '*':
                    resultado = num1 * num2;
                    break;
            }
            return resultado;
        }
    }
}
