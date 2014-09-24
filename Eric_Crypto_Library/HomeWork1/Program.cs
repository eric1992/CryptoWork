using System.IO;
using System.Linq;
using Eric_Crypto_Library;
using Eric_Crypto_Library.CryptoSystems;
using Eric_Crypto_Library.Keys.Enumerators;

namespace HomeWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Generate output for question 1.
            Q1();
            //Generate output for question 2.
            Q4();
        }

        /// <summary>
        /// Used to solve question 1.
        /// </summary>
        static void Q1()
        {
            var cipherText = "XLJMPHPDSZFWOOPDTRYLXZCPDPNFCPDJDEPX".ToLowerInvariant().ToCharArray();
            var keyEnumerator = new ShiftKeyEnumerator();
            var cryptoSys = new ShiftCipher();
            string plainText = "";

            //Defines the file to dump out to.
            var resultFile = new StreamWriter(@"C:\Users\Eric\Dropbox\Fall2014\Crypto\HW1\Question1Out.txt");

            //Iterate over each of the possible keys and print the plain text with the corresponding key to the designated text file.
            do
            {
                //Decrypt and converter from IEnumerable to array of chars to finally a string.
                plainText = new string(cryptoSys.Decrypt(cipherText, keyEnumerator.Current).ToArray());
                resultFile.WriteLine("Key " + keyEnumerator.Current.Shift + ": " + plainText);
            } while (keyEnumerator.MoveNext());
            resultFile.Close();
        }

        static void Q4()
        {
            var cipherInput = "AKVFZVZVSEFFIEYFITZFSEVKVAUFSQZVYVIXQUHIZEFXFQZLG".ToLowerInvariant().ToCharArray();
            var analyzer = new CharacterAnalyzer();
            var cryptoSys = new AffineCipher();
            var enumerator = new AffineKeyEnumerator();
            analyzer.Text = cipherInput;
            //Defines the file to dump out to.
            var resultFile = new StreamWriter(@"C:\Users\Eric\Dropbox\Fall2014\Crypto\HW1\Question2Out.txt");

            analyzer.CharacterCounts = analyzer.CharacterCounts.OrderByDescending(kp => kp.Value).ToDictionary(kp => kp.Key, kp => kp.Value);
            resultFile.WriteLine(analyzer.ToString());

            do
            {
                var outer = new string(cryptoSys.Decrypt(cipherInput, enumerator.Current).ToArray());
                resultFile.WriteLine(outer);

            } while (enumerator.MoveNext());
            
            resultFile.Close();
        }
    }
}
