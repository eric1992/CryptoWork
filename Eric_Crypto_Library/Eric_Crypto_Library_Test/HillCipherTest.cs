using Eric_Crypto_Library.CryptoSystems;
using Eric_Crypto_Library.Keys;
using NUnit.Framework;

namespace Eric_Crypto_Library_Test
{
    [TestFixture]
    class HillCipherTest
    {
        HillCipherTwoByTwoKey key;
        HillCipherTwoByTwo cipher;

        [Test]
        public void SloppyTest()
        {
            var plainText = "solved";
            var cipherText = "cgvzud";
            key = new HillCipherTwoByTwoKey(7,12,6,11);
            cipher = new HillCipherTwoByTwo();
            Assert.AreEqual(cipherText, cipher.Encrypt(plainText, key));
            Assert.AreEqual(plainText, cipher.Decrypt(cipherText, key));

        }
    }
}
