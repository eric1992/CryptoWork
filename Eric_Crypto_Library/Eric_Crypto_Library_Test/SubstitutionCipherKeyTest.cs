using System.Collections.Generic;
using System.Text;
using Eric_Crypto_Library;
using NUnit.Framework;

namespace Eric_Crypto_Library_Test
{
    [TestFixture]
    public class SubstitutionCipherKeyTest
    {
        public Dictionary<int, int> Substitutions;
        public SubstitutionCipherKey Key;

        [SetUp]
        public void Setup()
        {
            Substitutions = new Dictionary<int, int>();
        }

        [Test]
        public void TestInvalidArrayLengths()
        {
            for (var i = 1; i < 25; i++)
            {
                Substitutions = new Dictionary<int, int>(i);
                Key = new SubstitutionCipherKey(Substitutions);
                Assert.IsNull(Key.ToString());
            }
        }

        [Test]
        public void NullSubstitution()
        {
            for (int i = 0; i < 26; i++)
            {
                Substitutions[i] = i;
            }
            Key = new SubstitutionCipherKey(Substitutions);
            var expected = new StringBuilder();
            expected.Append("0");
            for (int i = 1; i < 26; i++)
            {
                expected.Append("," + i);
            }

            Assert.AreEqual(expected.ToString(), Key.ToString());
        }
    }
}
