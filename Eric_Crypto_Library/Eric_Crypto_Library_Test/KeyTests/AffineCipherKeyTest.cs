using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eric_Crypto_Library.Keys;
using NUnit.Framework;

namespace Eric_Crypto_Library_Test.KeyTests
{
    [TestFixture]
    class AffineCipherKeyTest
    {
        private AffineCipherKey key;

        [Test]
        public void TestConstructor()
        {
            key = new AffineCipherKey(1, 0);
            var expectedSubs = new Dictionary<int, int>(26);
            for (int i = 0; i < 26; i++)
            {
                expectedSubs.Add(i, i);
            }
            Assert.AreEqual(expectedSubs, key.PlainToCipher);
        }
    }
}
