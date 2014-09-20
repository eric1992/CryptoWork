using System;
using System.Collections.Generic;
using System.Linq;
using Eric_Crypto_Library.Keys;

namespace Eric_Crypto_Library.CryptoSystems
{
    public class PolyAlphabeticCipher : ICryptoSystem<IEnumerable<char>, IEnumerable<char>, PolyAlphabeticCipherKey>
    {
        private static readonly char[] PossiblePlainText = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        private static readonly char[] PossibleCipherText = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        public IEnumerable<char> GetPlainText()
        {
            return PossiblePlainText;
        }

        public IEnumerable<char> GetCipherText()
        {
            return PossibleCipherText;
        }

        public IEnumerator<PolyAlphabeticCipherKey> GetPossibleKeys()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<char> Encrypt(IEnumerable<char> input, PolyAlphabeticCipherKey key)
        {
            var plainTextInt = input.Select(CharToIntConverter.Convert);
            var cipherTextInt = Encrypt(plainTextInt, key);
            var cipherTextChar = cipherTextInt.Select(CharToIntConverter.Convert);
            return cipherTextChar;
        }

        protected IEnumerable<int> Encrypt(IEnumerable<int> plainTextInt, PolyAlphabeticCipherKey key)
        {
            var textInt = plainTextInt as int[] ?? plainTextInt.ToArray();
            var cipherTextInt = new List<int>(textInt.Count());

            int currentPlain, currentCipher;
            SubstitutionCipherKey currentKey;
            for (int textIndex = 0, keyIndex = 0; textIndex < textInt.Count(); textIndex++, keyIndex = (keyIndex + 1) % key.Keys.Count)
            {
                currentKey = key.Keys.ElementAt(keyIndex);
                currentPlain = textInt.ToList()[textIndex];
                currentCipher = currentKey.PlainToCipher[currentPlain];
                cipherTextInt.Add(currentCipher);
            }
            return cipherTextInt;
        }

        public IEnumerable<char> Decrypt(IEnumerable<char> input, PolyAlphabeticCipherKey key)
        {
            var cipherTextInt = input.Select(CharToIntConverter.Convert);
            var plainTextInt = Decrypt(cipherTextInt, key);
            var plainTextChar = plainTextInt.Select(CharToIntConverter.Convert);
            return plainTextChar;
        }

        protected IEnumerable<int> Decrypt(IEnumerable<int> cipherTextInt, PolyAlphabeticCipherKey key)
        {
            var textInt = cipherTextInt as int[] ?? cipherTextInt.ToArray();
            var plainTextInt = new List<int>(textInt.Count());

            int currentCipher, currentPlain;
            SubstitutionCipherKey currentKey;
            for (int textIndex = 0, keyIndex = 0; textIndex < textInt.Count(); textIndex++, keyIndex = (keyIndex + 1) % key.Keys.Count)
            {
                currentKey = key.Keys.ElementAt(keyIndex);
                currentCipher = textInt.ElementAt(textIndex);
                currentPlain = currentKey.PlainToCipher.First(g => g.Value == currentCipher).Key;
                plainTextInt.Add(currentPlain);
            }
            return plainTextInt;
        }
    }

}
