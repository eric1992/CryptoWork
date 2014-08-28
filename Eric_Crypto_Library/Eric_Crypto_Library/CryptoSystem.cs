using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eric_Crypto_Library
{
    public interface ICryptoSystem
    {
        IEnumerable<char> GetPlainText();
        IEnumerable<char> GetCipherText();
        IEnumerable<object> GetPossibleKeys();
        IEnumerable<char> Encrypt(IEnumerable<char> input, IKey key);
        IEnumerable<char> Decrypt(IEnumerable<char> input, IKey key);
    }
}
