using System;
using System.Collections.Generic;
using System.Linq;
using Eric_Crypto_Library.Keys;

namespace Eric_Crypto_Library.CryptoSystems
{
    public class VigenereCipher : PolyAlphabeticCipher, ICryptoSystem<IEnumerable<char>, IEnumerable<char>, VigenereCipherKey>
    {
        public IEnumerator<VigenereCipherKey> GetPossibleKeys()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<char> Encrypt(IEnumerable<char> input, VigenereCipherKey key)
        {
            var intPlain = input.Select(CharToIntConverter.Convert);
            var intCipher = Encrypt(intPlain, key);
            var charCipher = intCipher.Select(CharToIntConverter.Convert);
            return charCipher;
        }

        public IEnumerable<char> Decrypt(IEnumerable<char> input, VigenereCipherKey key)
        {
            var intCipher = input.Select(CharToIntConverter.Convert);
            var intPlain = Decrypt(intCipher, key);
            var charPlain = intPlain.Select(CharToIntConverter.Convert);
            return charPlain;
        }
    }
}
