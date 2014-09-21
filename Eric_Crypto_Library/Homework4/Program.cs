using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using Eric_Crypto_Library;

namespace Homework4
{
    static class Program
    {
        static void Main(string[] args)
        {
            Q1TextConversion();
        }

        static void Q1TextConversion()
        {
            var plain = "solved";
            var cipher = "cgvzud";
            var plainInt = plain.Select(CharToIntConverter.Convert).ToArray().ArrayToString();
            var cipherInt = cipher.Select(CharToIntConverter.Convert).ToArray().ArrayToString();
            var writer =
                new StreamWriter(
                    @"C:\Users\Eric\Documents\GitHub\CryptoWork\Eric_Crypto_Library\Homework4\bin\Debug\ConvertedStrings.txt");
            writer.WriteLine(plain + ":" + plainInt);
            writer.WriteLine(cipher + ":" + cipherInt);
            writer.Close();
        }

        static string ArrayToString(this int[] a)
        {
            var builder = new StringBuilder("{");
            foreach (var i in a)
            {
                builder.Append(i +",");
            }
            builder.Remove(builder.Length - 1, 1);
            builder.Append("}");
            return builder.ToString();
        }
    }

}
