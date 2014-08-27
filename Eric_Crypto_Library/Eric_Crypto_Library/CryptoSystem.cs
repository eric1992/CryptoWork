using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eric_Crypto_Library
{
    public interface CryptoSystem
    {
        public IEnumerable<char> getPlainText();
        public IEnumerable<char> getCipherText();
        public IEnumerable<string> getPossibleKeys();
        public IEnumerable<char> encrypt(IEnumerable<char> input, string key);
        public IEnumerable<char> decrypt(IEnumerable<char> input, string key);
    }
}
