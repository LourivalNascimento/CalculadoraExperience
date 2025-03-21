using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraExperience
{
    internal class Operations
    {
        private double resultado = 0;
        private double numNeutro = 0;
        //List<double> numeros = new List<double>();
        public Operations() 
        {
            
        }
        public double Somar(List<double> numeros)
        {
            for (int i = 0; i < numeros.Count; i++)
            {
                resultado += numeros[i];
            }
            return resultado;
        }
        public double Subtrair(double num1, double num2)
        {
            resultado = num1 - num2;
            return resultado;
        }
        public double Dividir(double num1, double num2)
        {
            resultado = num1 / num2;
            return resultado;
        }
        public double Multiplicar(double num1, double num2)
        {
            resultado = num1 * num2;
            return resultado;
        }
    }
}
