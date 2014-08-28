using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Eric_Crypto_Library
{
    public class ShiftCipher : ICryptoSystem
    {
        private static readonly List<char> PlainTextAlphabet = "abcdefghijklmnopqrstuvqxyz".ToCharArray().ToList();

        private static readonly List<char> CipherTestAlphabet =
            "abcdefghijklmnopqrstuvqxyz".ToUpperInvariant().ToCharArray().ToList(); 

        private static readonly List<ShiftCipherKey> PossibleKeys = new List<int> {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25}.Select(g => ShiftCipherKey.Parse(g)).ToList(); 

        public IEnumerable<char> GetPlainText()
        {
            return PlainTextAlphabet;
        }

        public IEnumerable<char> GetCipherText()
        {
            return CipherTestAlphabet;
        }

        IEnumerable<object> ICryptoSystem.GetPossibleKeys()
        {
            return GetPossibleKeys();
        }

        public IEnumerable<char> Encrypt(IEnumerable<char> input, IKey key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<char> Decrypt(IEnumerable<char> input, IKey key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IKey> GetPossibleKeys()
        {
            return (IEnumerable<object>) PossibleKeys;
        }

        public IEnumerable<char> Encrypt(IEnumerable<char> input, ShiftCipherKey key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<char> Decrypt(IEnumerable<char> input, string key)
        {
            throw new NotImplementedException();
        }
    }

    public class ShiftCipherKey : IKey
    {
        public int Shift;
        public string GetAsString()
        {
            return Shift.ToString();
        }

        public static ShiftCipherKey Parse(int i)
        {
            return  new ShiftCipherKey() {Shift = i % 26};
        }
    }
}
