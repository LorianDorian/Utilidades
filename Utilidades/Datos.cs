using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Utilidades
{
    public class Datos
    {
        public static bool ValidateUrl(string url)
        {
            // Try to create a Uri instance from the provided URL string
            if (Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult))
            {
                // Check if the Uri scheme is HTTP or HTTPS
                return uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps;
            }

            return false;
        }

        public static bool IsNumberValid(string input)
        {
            // Check if the input is null or empty
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            // Check if the input has exactly 10 characters
            if (input.Length != 10)
            {
                return false;
            }

            // Check if each character is a digit
            foreach (char c in input)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }

            return true;
        }

        public class NumberValidator
        {
            public static bool IsNumberSame(int number1, int number2)
            {
                return number1 == number2;
            }
        }

        public static int CountWords(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            int count = 0;
            bool inWord = false;

            foreach (char c in input)
            {
                if (char.IsWhiteSpace(c))
                {
                    inWord = false;
                }
                else
                {
                    if (!inWord)
                    {
                        count++;
                    }
                    inWord = true;
                }
            }

            return count;
        }

        public static bool ContainsWords(string input, params string[] words)
        {
            foreach (string word in words)
            {
                if (!input.Contains(word))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool ContainsLetters(string input, params char[] letters)
        {
            foreach (char letter in letters)
            {
                if (input.IndexOf(letter) == -1)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            // Split the email address into local part and domain part
            string[] parts = email.Split('@');
            if (parts.Length != 2)
            {
                return false;
            }

            string localPart = parts[0];
            string domainPart = parts[1];

            // Check if local part and domain part are not empty
            if (string.IsNullOrEmpty(localPart) || string.IsNullOrEmpty(domainPart))
            {
                return false;
            }

            // Check if domain part contains a dot
            if (!domainPart.Contains('.'))
            {
                return false;
            }

            return true;
        }

    }
}
