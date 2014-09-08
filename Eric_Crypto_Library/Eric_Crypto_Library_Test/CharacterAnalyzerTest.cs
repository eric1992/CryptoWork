using Eric_Crypto_Library;
using NUnit.Framework;

namespace Eric_Crypto_Library_Test
{
    [TestFixture]
    class CharacterAnalyzerTest
    {
        public CharacterAnalyzer Analyzer;

        [SetUp]
        public void Setup()
        {
            Analyzer = new CharacterAnalyzer(3);
        }

        [Test]
        public void TestBasic()
        {
            var input = "aabcdefgg";
            Analyzer.Text = input;
            var expected = "The Counts:\n(a, 2)\n(b, 1)\n(c, 1)\n(d, 1)\n(e, 1)\n(f, 1)\n(g, 2)";
            var actual = Analyzer.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
