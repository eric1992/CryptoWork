using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Eric_Crypto_Library;
using Eric_Crypto_Library.CryptoSystems;
using Eric_Crypto_Library.Keys;

namespace Homework4
{
    static class Program
    {
        static void Main()
        {
            Q1TextConversion();
            Q2TextDiagramAnalysis();
            keyGen();
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

        static void Q2TextDiagramAnalysis()
        {
            var cipherText =
                "LMQETXYEAGTXCTUIEWNCTXLZEWUAISPZYVAPEWLMGQWYAXFTCJMSQCADAGTXLMDXNXSNPJQSYVAPRIQSMHNOCVAXFV"
                    .ToLowerInvariant();
            var anaylzer = new CharacterAnalyzer() {Text = cipherText};
            var diagrams = anaylzer.DiagramCount;
        }

        static void keyGen()
        {
            var a1 = new HillCipherTwoByTwoKey(19, 7, 7, 4).Inverse;
            var a2 = new HillCipherTwoByTwoKey(7, 4, 8, 13).Inverse;
            var a3 = new HillCipherTwoByTwoKey(8, 13, 19, 7).Inverse;

            var B = new HillCipherTwoByTwoKey(19, 23, 11, 12);

            var listAs = new List<HillCipherTwoByTwoKey> {a1, a2, a3};

            var listKs = (from aInv in listAs 
                          let kA = (aInv.A*B.A) + (aInv.B*B.C) 
                          let kB = (aInv.A*B.B) + (aInv.B*B.D) 
                          let kC = (aInv.C*B.A) + (aInv.D*B.C) 
                          let kD = (aInv.C*B.B) + (aInv.D*B.D) 
                          select new HillCipherTwoByTwoKey(kA, kB, kC, kD))
                          .ToList();

            var cipherText =
                "LMQETXYEAGTXCTUIEWNCTXLZEWUAISPZYVAPEWLMGQWYAXFTCJMSQCADAGTXLMDXNXSNPJQSYVAPRIQSMHNOCVAXFV"
                    .ToLowerInvariant();

            var cipher = new HillCipherTwoByTwo();
            var plains = listKs.Select(k => new string(cipher.Decrypt(cipherText, k).ToArray())).ToList();

        }
    }

}
