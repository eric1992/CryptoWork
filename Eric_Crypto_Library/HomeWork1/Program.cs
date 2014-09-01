using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using Eric_Crypto_Library;

namespace HomeWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            Q1();
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
    }
}
