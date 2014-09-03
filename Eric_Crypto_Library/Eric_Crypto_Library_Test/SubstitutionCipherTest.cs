using System.Collections.Generic;
using Eric_Crypto_Library;
using Eric_Crypto_Library.Keys;
using NUnit.Framework;

namespace Eric_Crypto_Library_Test
{
    [TestFixture]
    class SubstitutionCipherTest
    {
        private SubstitutionCipher _Cipher;
        public SubstitutionCipherKey Key;
        public IEnumerable<char> Message = "dogeatdog".ToCharArray();
        public SubstitutionCipher Cipher
        {
            get { return _Cipher; }
            set { _Cipher = value; }
        }

        public Dictionary<int, int> nullSub;
        public Dictionary<int, int> evenOddSub;
            
        [SetUp]
        public void Setup()
        {
            _Cipher = new SubstitutionCipher();
            nullSub = new Dictionary<int, int>();
            for (var i = 0; i < 26; i++)
            {
                nullSub.Add(i,i);
            }
            evenOddSub = new Dictionary<int, int>();
            for (var i = 0; i < 13; i++)
            {
                evenOddSub.Add(i, 2 * i);
            }
            for (var i = 13; i < 26; i++)
            {
                evenOddSub.Add(i, 2 * (i - 13) + 1);
            }
        }

    }
}
