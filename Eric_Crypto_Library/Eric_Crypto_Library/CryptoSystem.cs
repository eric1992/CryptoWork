using System.Collections.Generic;

namespace Eric_Crypto_Library
{
    public interface ICryptoSystem
    {
        IEnumerable<char> GetPlainText();
        IEnumerable<char> GetCipherText();
        IEnumerator<IKey> GetPossibleKeys();
        IEnumerable<char> Encrypt(IEnumerable<char> input, IKey key);
        IEnumerable<char> Decrypt(IEnumerable<char> input, IKey key);
    }
}