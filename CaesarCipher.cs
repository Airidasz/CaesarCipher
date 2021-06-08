using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
    /// <summary>
    /// This class contains methods for caesar cipher encryption and decryption
    /// And works only with the original ascii characters a-z and A-Z
    /// numbers or any other symbols are ignored
    /// </summary>
    public class CaesarCipher
    {
        private const string AlphabetLetters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const int LetterCount = 26;

        private static (int, int) UppercaseBounds = (65, 90);
        private static (int, int) LowercaseBounds = (97, 122);

        public static string Encrypt(string text, int offset)
        {
            var encryptedText = text.ToCharArray().Where(x => AlphabetLetters.Contains(x)).Select(x => {
                // Ascii limits for uppercase or lowercase letter
                (int lowerBound, int upperBound) = Char.IsLower(x) ? LowercaseBounds : UppercaseBounds;

                // Get encrypted character ascii code
                int encryptedCharAsciiCode = Mod(x + offset - lowerBound, LetterCount) + lowerBound;

                return (char)encryptedCharAsciiCode;
                }).ToArray();

            return new string(encryptedText);
        }

        // Decryption function uses the encryption function
        // with a negative offset
        public static string Decrypt(string text, int offset)
        {
            return Encrypt(text, offset * -1);
        }

        // This function finds the mathematical modulus of two integers
        // This differs from the c# provided % operator
        // Because c# % is a remainder operator
        // And does not work with negative values
        private static int Mod(int a, int b)
        {
            return (Math.Abs(a * b) + a) % b;
        }
    }
}
