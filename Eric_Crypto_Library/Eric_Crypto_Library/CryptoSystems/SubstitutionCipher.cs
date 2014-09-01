using System;
using System.Collections.Generic;
using System.Linq;

namespace Eric_Crypto_Library
{
    /// <summary>
    /// Encrypts a "list" of plain text characters to a "list" of cipher text characters. Takes a SubstitutionCipherKey to encrypt and decrypt
    /// </summary>
    public class SubstitutionCipher : ICryptoSystem<IEnumerable<char>, IEnumerable<char>, SubstitutionCipherKey>  
    {
        private static readonly char[] PossiblePlainText = 
        { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        private static readonly char[] PossibleCipherText = 
        { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        public IEnumerable<char> GetPlainText()
        {
            return PossiblePlainText;
        }

        public IEnumerable<char> GetCipherText()
        {
            return PossibleCipherText;
        }

        public IEnumerator<SubstitutionCipherKey> GetPossibleKeys()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<char> Encrypt(IEnumerable<char> input, SubstitutionCipherKey key)
        {
            var intInput = input.Select(CharToIntConverter.Convert);
            var intCipherText = Encrypt(intInput, key);
            var charCipherText = intCipherText.Select(CharToIntConverter.Convert);
            return charCipherText;
        }

        public IEnumerable<char> Decrypt(IEnumerable<char> input, SubstitutionCipherKey key)
        {
            var intCipherText = input.Select(CharToIntConverter.Convert);
            var intPlainText = Decrypt(intCipherText, key);
            var charPlainText = intPlainText.Select(CharToIntConverter.Convert);
            return charPlainText;
        }


        protected IEnumerable<int> Encrypt(IEnumerable<int> input, SubstitutionCipherKey key)
        {
            var encryOutput = input.Select(g => key.PlainToCipher[g]);
            return encryOutput;
        }

        protected IEnumerable<int> Decrypt(IEnumerable<int> input, SubstitutionCipherKey key)
        {
            var decryOuput = input.Select(g => key.PlainToCipher[g]);
            return decryOuput;
        }
    }
}
