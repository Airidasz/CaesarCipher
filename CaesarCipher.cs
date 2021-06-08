using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
    /// <summary>
    /// This class contains methods for caesar cipher encryption and decryption
    /// And works only with the original ascii leters a-z and A-Z
    /// numbers or any other simbols do not work and are ignored
    /// </summary>
    class CaesarCipher
    {
        private const string AlphabetLetters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const int LetterCount = 26;

        private static (int, int) UppercaseBounds = (65, 90);
        private static (int, int) LowercaseBounds = (97, 122);

        public static string Encrypt(string text, int offset)
        {
            var encryptedText = text.ToCharArray().Where(x => AlphabetLetters.Contains(x)).Select(x => {
                // Upper and lower bounds for upper or lower case ascii characters 
                (int lowerBound, int upperBound) = GetBoundsForChar(x);

                int encryptedCharAsciiCode = x + offset;

                if (encryptedCharAsciiCode > upperBound || encryptedCharAsciiCode < lowerBound)
                    encryptedCharAsciiCode = Mod(encryptedCharAsciiCode - lowerBound, LetterCount) + lowerBound;


                return (char)encryptedCharAsciiCode;
                }).ToArray();

            return new string(encryptedText);
        }

        public static string Decrypt(string text, int offset)
        {
            var decryptedText = text.ToCharArray().Where(x => AlphabetLetters.Contains(x)).Select(x => {
                // Upper and lower bounds for upper or lower case ascii characters 
                (int lowerBound, int upperBound) = GetBoundsForChar(x);

                int decryptedCharAsciiCode = x - offset;

                if (decryptedCharAsciiCode > upperBound || decryptedCharAsciiCode < lowerBound)
                    decryptedCharAsciiCode = Mod(decryptedCharAsciiCode - lowerBound, LetterCount) + lowerBound;

                return (char)decryptedCharAsciiCode;
            }).ToArray();

            return new string(decryptedText);
        }

        // function returns lower and upper bounds
        // for a given character
        // for lowercase characters ascii codes of a and z are returned
        // for uppercase - ascii codes of A and Z
        private static (int, int) GetBoundsForChar(char c)
        {
            return Char.IsLower(c) ? UppercaseBounds : LowercaseBounds;
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
