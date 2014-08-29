using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using Eric_Crypto_Library;
using NUnit.Framework;

namespace Eric_Crypto_Library_Test
{
    [TestFixture]
    class SubstitutionCipherTest
    {
        public SubstitutionCipher cipher;
        public SubstitutionCipherKey key;
        public Dictionary<int, int> nullSub;
        public Dictionary<int, int> evenOddSub;
            
        [SetUp]
        public void Setup()
        {
            cipher = new SubstitutionCipher();
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

        [Test]
        public void TestIntegerEncrypt()
        {
            key = new SubstitutionCipherKey(nullSub);
            var message = new int[] {1, 2, 3, 4, 5, 6, 7, 10};
            Assert.AreEqual(message, cipher.Encrypt(message, key));
            var evenOddCipherMessage = new int[] {2, 4, 6, 8, 10, 12, 14, 20};
            key = new SubstitutionCipherKey(evenOddSub);
            Assert.AreEqual(evenOddCipherMessage, cipher.Encrypt(message, key));
        }

        [Test]
        public void TestIntegerDecrypt()
        {
            key = new SubstitutionCipherKey(nullSub);
            var message = new int[] { 1, 2, 3, 4, 5, 6, 7, 10 };
            var messageEncrypt = cipher.Encrypt(message, key);
            Assert.AreEqual(message, cipher.Decrypt(messageEncrypt, key));
            key = new SubstitutionCipherKey(evenOddSub);
            messageEncrypt = cipher.Encrypt(message, key);
            Assert.AreEqual(message, cipher.Decrypt(messageEncrypt, key));
        }
    }
}
