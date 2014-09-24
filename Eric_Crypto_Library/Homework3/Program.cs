using System;
using System.Collections.Generic;
using System.Linq;
using Eric_Crypto_Library;
using Eric_Crypto_Library.CryptoSystems;
using Eric_Crypto_Library.Keys;

namespace Homework3
{
    class Program
    {
        static void Main(string[] args)
        {
           Q1Again();   
        }

        static void Q1()
        {
            var input = "OCISEWMPKEAGZZAJGSKPRSMKHCVRZXQCJKMVDVTICFRHPNPFUOBKVXIRBRTGRSEZSA" +
                        "TRXHRGKGRCZRTKDOXKWRHZYXAIVZLJHKNIVCJZEWQZKRCDVUTUSJZLNTZXWCZZHVJFZ" +
                        "GRBSDVPXMVJEUOEMYJUVWYRHVJMOTVXIWHWXSVHYKSWSNKWYSRQXXRRE";
            var analyer = new CoincidenceAnalyzer();
            analyer.Text = input;
            /*for (int i = 2; i < 22; i++)
            {
                Console.WriteLine(i + ", " + analyer.IndexFor(i));
            }*/
            Console.ReadKey(true);

            var dicts = analyer.FreqOnNSubs(5);
            foreach (var characterAnalyzer in dicts)
            {
                Console.WriteLine(characterAnalyzer.Value.ToString());
            }
            Console.ReadKey(true);
        }

        static void Q1Again()
        {
            var cipherText = "OCISEWMPKEAGZZAJGSKPRSMKHCVRZXQCJKMVDVTICFRHPNPFUOBKVXIRBRTGRSEZSA" +
                        "TRXHRGKGRCZRTKDOXKWRHZYXAIVZLJHKNIVCJZEWQZKRCDVUTUSJZLNTZXWCZZHVJFZ" +
                        "GRBSDVPXMVJEUOEMYJUVWYRHVJMOTVXIWHWXSVHYKSWSNKWYSRQXXRRE";
            cipherText = cipherText.ToLowerInvariant();
            var cipher = new VigenereCipher();
            var k1 = new List<char> {'r','j','w' };
            var k2 = new List<char> { 's','h'};
            var k3 = new List<char> {'v','r','z' };
            var k4 = new List<char> {'k','z','x' };
            var k5 = new List<char> { 'e','i'};
            foreach (var a in k1)
            {
                foreach (var b in k2)
                {
                    foreach (var c in k3)
                    {
                        foreach (var d in k4)
                        {
                            foreach (var e in k5)
                            {
                                var keysTries = new List<char> {a,b,c,d,e }.Select(g => CharToIntConverter.Convert(g) - CharToIntConverter.Convert('e')).Select(g => new ShiftCipherKey(g)).ToList();
                                var key = new VigenereCipherKey(keysTries);
                                var output = cipher.Decrypt(cipherText.ToCharArray(), key).ToArray();
                                Console.WriteLine(new string(output));
                            }
                        }
                    }
                }
            }
            Console.ReadKey(true);
        }

        static void Q2()
        {
           /* var cipher = new HillCipher();
            var r1 = new double[] {3, 2};
            var r2 = new double[] {5, 11};
            var mBuilder = Matrix<double>.Build;
            var keyMatrix = mBuilder.DenseOfRowArrays(new List<double[]> {r1, r2});
            var key = new HillCipherTwoByTwoKey(26, keyMatrix);
            var cipherText = "BOTLTN".ToLower().ToCharArray().ToList().Select(CharToIntConverter.Convert).ToList();
            var decText = new[] { 271, 368, 304, 617, 342, 667 };
            var a = decText.ToList().Select(g => g%26);
            var b = a.Select(CharToIntConverter.Convert).ToList();*/
        }
    }
}
