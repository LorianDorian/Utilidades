using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    internal class Hash
    {
        private static byte[] key = Encoding.UTF8.GetBytes("16ByteKeyForAES_"); // 16-byte key for AES encryption
        private static byte[] iv = Encoding.UTF8.GetBytes("16ByteIVForAES__"); // 16-byte initialization vector for AES encryption

        public static string Encrypt(string plainText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public static string EncryptWithCustomKey(string plainText, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] iv = new byte[16]; // Use a fixed IV for simplicity, but for real-world scenarios, generate a random IV for each encryption
            byte[] encrypted;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = keyBytes;
                aesAlg.IV = iv;
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(encrypted);
        }

        public static string CaesarDecrypt(string cipherText, int shift)
        {
            StringBuilder plainText = new StringBuilder();

            foreach (char c in cipherText)
            {
                if (char.IsLetter(c))
                {
                    char decryptedChar = (char)(c - shift);
                    if ((char.IsLower(c) && decryptedChar < 'a') || (char.IsUpper(c) && decryptedChar < 'A'))
                    {
                        decryptedChar = (char)(decryptedChar + 26);
                    }
                    plainText.Append(decryptedChar);
                }
                else
                {
                    plainText.Append(c);
                }
            }

            return plainText.ToString();
        }

        public static string CaesarEncrypt(string plainText, int shift)
        {
            StringBuilder cipherText = new StringBuilder();

            foreach (char c in plainText)
            {
                if (char.IsLetter(c))
                {
                    char encryptedChar = (char)(c + shift);
                    if ((char.IsLower(c) && encryptedChar > 'z') || (char.IsUpper(c) && encryptedChar > 'Z'))
                    {
                        encryptedChar = (char)(encryptedChar - 26);
                    }
                    cipherText.Append(encryptedChar);
                }
                else
                {
                    cipherText.Append(c);
                }
            }

            return cipherText.ToString();
        }

        public static string AtbashEncrypt(string message)
        {
            StringBuilder encryptedMessage = new StringBuilder();

            foreach (char c in message)
            {
                if (char.IsLetter(c))
                {
                    char encryptedChar = (char)(('Z' - char.ToUpper(c)) + 'A');
                    encryptedMessage.Append(char.IsLower(c) ? char.ToLower(encryptedChar) : encryptedChar);
                }
                else
                {
                    encryptedMessage.Append(c);
                }
            }

            return encryptedMessage.ToString();
        }

        public static string AtbashDecrypt(string cipherText)
        {
            StringBuilder decryptedMessage = new StringBuilder();

            foreach (char c in cipherText)
            {
                if (char.IsLetter(c))
                {
                    char decryptedChar = (char)(('Z' - char.ToUpper(c)) + 'A');
                    decryptedMessage.Append(char.IsLower(c) ? char.ToLower(decryptedChar) : decryptedChar);
                }
                else
                {
                    decryptedMessage.Append(c);
                }
            }

            return decryptedMessage.ToString();
        }
    }
}
