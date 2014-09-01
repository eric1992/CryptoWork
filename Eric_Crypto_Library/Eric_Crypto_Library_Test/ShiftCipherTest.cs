using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eric_Crypto_Library;
using NUnit.Framework;

namespace Eric_Crypto_Library_Test
{

    [TestFixture]
    class ShiftCipherTest
    {
        private IEnumerable<char> Message;
        private ShiftCipher cipher;
        private ShiftCipherKey key;

        [SetUp]
        public void SetUp()
        {
            cipher = new ShiftCipher();
        }

        [Test]
        public void TestInvalidShifts()
        {
            Message = "dog".ToCharArray();
            key = new ShiftCipherKey(0);
            cipher = new ShiftCipher();

        }
    }
}
