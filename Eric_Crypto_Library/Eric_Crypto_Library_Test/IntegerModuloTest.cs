using System;
using Eric_Crypto_Library;
using NUnit.Framework;

namespace Eric_Crypto_Library_Test
{
    [TestFixture]
    public class IntegerModuloTest
    {
        [Test]
        public void TestConstruction()
        {
            Assert.Throws<ArgumentException>(() => new IntegerModulo(-1, 1));
            Assert.Throws<ArgumentException>(() => new IntegerModulo(0, 1));

            var test = new IntegerModulo(1, 5);
            Assert.AreEqual(1, test.Modulo);
            Assert.AreEqual(0, test.Value);

            test = new IntegerModulo(5, 1);
            Assert.AreEqual(5, test.Modulo);
            Assert.AreEqual(1, test.Value);

            test.Value = 5;
            Assert.AreEqual(0, test.Value);

            test.Value = -6;
            Assert.AreEqual(4, test.Value);
        }

        [Test]
        public void TestAddition()
        {
            var a = new IntegerModulo(5, 3);
            var b = new IntegerModulo(5, 1);
            var c = new IntegerModulo(4, 1);

            var actual = a + b;
            Assert.AreEqual(4, actual.Value);

            b.Value = 2;
            actual = a + b;
            Assert.AreEqual(0, actual.Value);

            b.Value = 3;
            actual = a + b;
            Assert.AreEqual(1, actual.Value);

            Assert.Throws<Exception>(() => actual = a + c);
        }

        [Test]
        public void TestMultiplication()
        {
            var a = new IntegerModulo(5, 3);
            var b = new IntegerModulo(5, 3);
            var c = new IntegerModulo(4, 2);

            var actual = a * b;
            Assert.AreEqual(4, actual.Value);

            b.Value = 4;
            actual = a * b;
            Assert.AreEqual(2, actual.Value);

            Assert.Throws<Exception>(() => actual = a*c);
        }

        [Test]
        public void TestSubtraction()
        {
            var a = new IntegerModulo(5, 3);
            var b = new IntegerModulo(5, 3);
            var c = new IntegerModulo(4, 2);

            var actual = a - b;
            Assert.AreEqual(0, actual.Value);

            b.Value = 4;
            actual = a - b;
            Assert.AreEqual(4, actual.Value);

            Assert.Throws<Exception>(() => actual = a - c);
        }

        [Test]
        public void TestInverse()
        {
            var a = new IntegerModulo(5, 3);
            var actual = a.Inverse();
            Assert.AreEqual(2, actual.Value);

            a.Value = 2;
            actual = a.Inverse();
            Assert.AreEqual(3, actual.Value);

            a.Value = 4;
            actual = a.Inverse();
            Assert.AreEqual(4, actual.Value);

            a = new IntegerModulo(6, 2);
            Assert.Null(a.Inverse());
        }
    }
}
