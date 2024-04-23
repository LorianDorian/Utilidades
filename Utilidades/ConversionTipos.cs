using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public class ConversionTipos
    {
        public static string IntToString(int number)
        {
            bool isNegative = number < 0;
            if (isNegative)
            {
                number = -number; // Make the number positive for easier manipulation
            }

            string result = "";
            while (number > 0)
            {
                int digit = number % 10; // Extract the last digit
                char digitChar = (char)('0' + digit); // Convert the digit to a character
                result = digitChar + result; // Prepend the character to the result string
                number /= 10; // Move to the next digit
            }

            if (isNegative)
            {
                result = "-" + result; // Add the negative sign back if the original number was negative
            }

            return result;
        }

        public static int StringToInt(string str)
        {
            bool isNegative = false;
            int result = 0;
            int startIndex = 0;

            if (str[0] == '-')
            {
                isNegative = true;
                startIndex = 1;
            }

            for (int i = startIndex; i < str.Length; i++)
            {
                char digitChar = str[i];
                int digit = digitChar - '0'; // Convert the character to an integer value
                result = result * 10 + digit; // Add the digit to the result
            }

            if (isNegative)
            {
                result = -result; // Make the result negative if the input string was negative
            }

            return result;
        }

        public static int ExtractIntFromString(string str)
        {
            bool isNegative = false;
            int result = 0;
            int startIndex = 0;

            // Check for negative sign at the beginning of the string
            if (str[0] == '-')
            {
                isNegative = true;
                startIndex = 1;
            }

            for (int i = startIndex; i < str.Length; i++)
            {
                char currentChar = str[i];

                // Check if the character is a digit (0-9)
                if (currentChar >= '0' && currentChar <= '9')
                {
                    int digit = currentChar - '0'; // Convert the character to an integer value
                    result = result * 10 + digit; // Add the digit to the result
                }
            }

            if (isNegative)
            {
                result = -result; // Make the result negative if the input string was negative
            }

            return result;
        }

        public static double StringToDouble(string str)
        {
            double result = 0.0;
            bool isNegative = false;
            int decimalIndex = -1;

            // Check for negative sign at the beginning of the string
            if (str[0] == '-')
            {
                isNegative = true;
            }

            // Iterate through each character in the string
            for (int i = isNegative ? 1 : 0; i < str.Length; i++)
            {
                char currentChar = str[i];

                // Check if the character is a digit (0-9)
                if (currentChar >= '0' && currentChar <= '9')
                {
                    int digit = currentChar - '0'; // Convert the character to an integer value
                    result = result * 10 + digit; // Add the digit to the result

                    // If decimalIndex is set, it means we are after the decimal point
                    if (decimalIndex != -1)
                    {
                        decimalIndex++; // Increment the decimalIndex to adjust the decimal place
                    }
                }
                else if (currentChar == '.' && decimalIndex == -1)
                {
                    // Handle decimal point
                    decimalIndex = 1;
                }
                else
                {
                    // Invalid character, break the loop
                    break;
                }
            }

            // Adjust the result for negative numbers
            if (isNegative)
            {
                result = -result;
            }

            // Adjust the result for the decimal point
            if (decimalIndex != -1)
            {
                result /= Math.Pow(10, decimalIndex);
            }

            return result;
        }

        public static char[] StringToCharArray(string str)
        {
            char[] charArray = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                charArray[i] = str[i]; // Assign each character from the string to the char array
            }
            return charArray;
        }
    }
}
