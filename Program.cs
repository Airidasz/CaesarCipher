using System;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            var regual = "a";
            var encrypted = CaesarCipher.Encrypt(regual, 1);
            Console.WriteLine(encrypted);
            Console.WriteLine(CaesarCipher.Decrypt(encrypted, 1));
        }
    }
}
