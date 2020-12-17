using System;
using System.Security.Cryptography;
using System.Text;

namespace Des
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            DESCryptoServiceProvider​​ des = new DESCryptoServiceProvider​​();
            byte[] key = new byte[8] { 49, 50, 51, 52, 53, 54, 55, 56 };
            //byte[] iv = new byte[8] { 45, 60, 61, 62, 63, 64, 65, 66 };
            des.Key=key;
            des.IV = key;
            string plaintext = "testo in chiaro";
            byte[] plainData = Encoding.UTF8.GetBytes(plaintext);
            string t = Encoding.UTF8.GetString(plainData);
            Console.WriteLine(t);
            ICryptoTransform enc = des.CreateEncryptor();
            byte[] encData = enc.TransformFinalBlock(plainData, 0, plainData.Length);
            string cipherText = Encoding.Unicode.GetString(encData);

            Console.WriteLine(cipherText);

            foreach (var item in encData)
                Console.Write(Convert.ToString(item, 16));

            Console.WriteLine();
            ICryptoTransform dec = des.CreateDecryptor();
            byte[] decData = dec.TransformFinalBlock(encData, 0, encData.Length);
            string decText = Encoding.ASCII.GetString(decData);
            Console.WriteLine(decText);
        }
    }
}
