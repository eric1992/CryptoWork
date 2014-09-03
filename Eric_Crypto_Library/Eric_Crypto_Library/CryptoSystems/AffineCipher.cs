using System.Collections.Generic;
using System.Linq;
using Eric_Crypto_Library.Keys;
using Eric_Crypto_Library.Keys.Enumerators;

namespace Eric_Crypto_Library.CryptoSystems
{
    public class AffineCipher : SubstitutionCipher, ICryptoSystem<IEnumerable<char>, IEnumerable<char>, AffineCipherKey>
    {
        public new IEnumerator<AffineCipherKey> GetPossibleKeys()
        {
            return new AffineKeyEnumerator();
        }

        public IEnumerable<char> Encrypt(IEnumerable<char> input, AffineCipherKey key)
        {
            var plainTextInt = input.Select(CharToIntConverter.Convert);
            var cipherTextInt = Encrypt(plainTextInt, key);
            var cipherTextChar = cipherTextInt.Select(CharToIntConverter.Convert);
            return cipherTextChar;
        }

        public IEnumerable<char> Decrypt(IEnumerable<char> input, AffineCipherKey key)
        {
            var cipherTextInt = input.Select(CharToIntConverter.Convert);
            var plainTextInt = Encrypt(cipherTextInt, key);
            var plainTextChar = plainTextInt.Select(CharToIntConverter.Convert);
            return plainTextChar;
        }
    }
}
