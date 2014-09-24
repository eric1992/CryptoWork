using System;
using Eric_Crypto_Library.Keys;
using NUnit.Framework;

namespace Eric_Crypto_Library_Test
{
    class ShiftCipherKeyTest
    {
        private ShiftCipherKey key;

        [Test]
        public void TestInvalidShift()
        {
            Assert.Throws<ArgumentException>(() => new ShiftCipherKey(-1));
            Assert.Throws<ArgumentException>(() => new ShiftCipherKey(26));
        }

        [Test]
        public void TestValidShift()
        {
            for (int shift = 0; shift < 26; shift++)
            {
                key = new ShiftCipherKey(shift);
                for (int index = 0; index < 26; index++)
                {
                    Assert.That(key.PlainToCipher[index] == (index + shift) % 26);
                }
                
            }
            
        }
    }
}
