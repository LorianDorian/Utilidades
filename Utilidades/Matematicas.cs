using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public class Matematicas
    {

        public static float Suma (params float[] numbers)
        {
            float resultado = 0; 
            foreach(float num in numbers)
            {
                resultado += num;
            }
            return resultado; 
        }

        public static float Resta (params float[] numbers)
        {
            float resultado = 0; 
            foreach(float num in numbers)
            {
                resultado -= num; 
            }
            return resultado;
        }

        public static float Multiplicacion (params float[] numbers)
        {
            float resultado = 0;
            
            foreach(float num in numbers)
            {
                resultado *= num; 
            }
            return resultado; 
        }

        public static int Potencia (int num, int potencia)
        {
            if (potencia < 0)
            {
                throw new ArgumentException("La potencia debe ser un número positivo.");
            }

            int resultado = 1;

            try
            {
                for (int i = 0; i < potencia; i++)
                {
                    resultado *= num;
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Error de desbordamiento: " + ex.Message);
            }
            return resultado; 
        } 

        public static int Division(float divisor, float dividendo)
        {
            if (divisor == 0)
            {
                throw new ArgumentException("El divisor debe ser un numero diferente de 0");
            }
        }
    }
}
