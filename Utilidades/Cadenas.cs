using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public class Cadenas
    {
        public static int ContadorCaracteres(string cadena)
        {

            int caracteres = 0;
            
            foreach (char caracter in cadena) 
            {
                caracteres++;
            }

            return caracteres;
        }

        public static string Concatenacion(params string[] cadenas)
        {
            int totalLength = 0;
            foreach (string cadena in cadenas)
            {
                totalLength += ContadorCaracteres(cadena);
            }

            char[] result = new char[totalLength];
            int currentIndex = 0;
            foreach (string cadena in cadenas)
            {
                foreach (char c in cadena)
                {
                    result[currentIndex++] = c;
                }
            }

            return new string(result);
        }

        public static List<string> Dividir(string cadena)
        {
            List<string> resultados = new List<string>();

            string palabra = "";

            foreach (char caracter in cadena)
            {


                if (caracter == ' ')
                {
                    resultados.Add(palabra);
                    palabra = "";
                }
                else
                {
                    palabra += caracter;
                }
            }

            if (!string.IsNullOrEmpty(palabra))
            {
                resultados.Add(palabra);
            }

            return resultados;
        }

        public static string Reemplazo(string cadena, string reemplazo, string palabraAreemplazar)
        {
            List<string> palabras = new List<string>(Dividir(cadena));

            for (int i = 0; i < palabras.Count; i++)
            {
                if (palabras[i] == palabraAreemplazar)
                {
                    palabras[i] = reemplazo;
                }
            }

            string resultado = string.Join(" ", palabras);

            return resultado;
        }

        public static string ToUpperCase(string input)
        {
            char[] chars = input.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] >= 'a' && chars[i] <= 'z')
                {
                    chars[i] = (char)(chars[i] - 32); 
                }
                else if (chars[i] >= 'à' && chars[i] <= 'ÿ')
                {
                    switch (chars[i])
                    {
                        case 'ñ':
                            chars[i] = 'Ñ';
                            break;
                        case 'á':
                            chars[i] = 'Á';
                            break;
                        case 'é':
                            chars[i] = 'É';
                            break;
                        case 'í':
                            chars[i] = 'Í';
                            break;
                        case 'ó':
                            chars[i] = 'Ó';
                            break;
                        case 'ú':
                            chars[i] = 'Ú';
                            break;
                        case 'ü':
                            chars[i] = 'Ü';
                            break;
                        default:
                            throw new ArgumentException("Special characters without uppercase equivalents are not supported.");
                            
                    }
                }
            }

            return new string(chars);
        }


    }

}
