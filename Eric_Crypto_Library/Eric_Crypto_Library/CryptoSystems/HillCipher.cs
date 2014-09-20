using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using Eric_Crypto_Library.Keys;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;
using MathNet.Numerics.LinearAlgebra.Storage;

namespace Eric_Crypto_Library.CryptoSystems
{
    public class HillCipher : ICryptoSystem<IEnumerable<char>, IEnumerable<char>, HillCipherKey>
    {
        public IEnumerable<char> GetPlainText()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<char> GetCipherText()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<HillCipherKey> GetPossibleKeys()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<char> Encrypt(IEnumerable<char> input, HillCipherKey key)
        {
            var intPlain = input.Select(CharToIntConverter.Convert);
            var intCipher = Encrypt(intPlain, key);
            var charCipher = intCipher.Select(CharToIntConverter.Convert);
            return charCipher;

        }

        private IEnumerable<int> Encrypt(IEnumerable<int> input, HillCipherKey key)
        {
            var intPlain = new List<int>(input);
            if (intPlain.Count % key.Dimension != 0)
            {
                while (intPlain.Count % key.Dimension != 0)
                {
                    intPlain.Add(0);
                }
            }
            var intPlainBlocks = new List<List<int>>();
            var tempBlock = new List<int>();
            for (var i = 0; i < intPlain.Count; i += key.Dimension)
            {
                tempBlock.Clear();
                for (var j = i; j < key.Dimension; j++)
                {
                    tempBlock.Add(intPlain[j]);
                }
                intPlainBlocks.Add(tempBlock);
            }
            var intCipher = new List<int>();
            foreach (var intPlainBlock in intPlainBlocks)
            {
                intCipher.AddRange(EncryptBlock(intPlainBlock, key));
            }
            return intCipher;
        }

        private IEnumerable<int> EncryptBlock(IEnumerable<int> input, HillCipherKey key)
        {
            if(input.Count() != key.Key.ColumnCount)
                throw new ArgumentException("Input must have same length as key's height and width.");
            var matrixBuilder = Matrix<double>.Build;
            var matrixPlain = matrixBuilder.DenseOfRowArrays(new[] {input.Select(g => (double)g).ToArray()});
            var matrixCipher = matrixPlain * key.Key;
            if(matrixCipher.RowCount != 1)
                throw new Exception("There should be only one row.");
            var intCipher = matrixCipher.Row(1).ToArray();
            var integerConverter = new IntegerModulo(key.Modulo, 0);
            for (int i = 0; i < intCipher.Count(); i++)
            {
                integerConverter.Value = (int)intCipher[i];
                intCipher[i] = integerConverter.Value;
            }
            return intCipher.Select(g => (int)g);

        }

        public IEnumerable<char> Decrypt(IEnumerable<char> input, HillCipherKey key)
        {
            var intPlain = input.Select(CharToIntConverter.Convert);
            var intCipher = Decrypt(intPlain, key);
            var charCipher = intCipher.Select(CharToIntConverter.Convert);
            return charCipher;
        }

        private IEnumerable<int> Decrypt(IEnumerable<int> input, HillCipherKey key)
        {
            var intCipher = new List<int>(input);
            if (intCipher.Count % key.Dimension != 0)
            {
                while (intCipher.Count % key.Dimension != 0)
                {
                    intCipher.Add(0);
                }
            }
            var intCipherBlocks = new List<List<int>>();
            var tempBlock = new List<int>();
            for (var i = 0; i < intCipher.Count; i += key.Dimension)
            {
                tempBlock.Clear();
                for (var j = i; j < key.Dimension; j++)
                {
                    tempBlock.Add(intCipher[j]);
                }
                intCipherBlocks.Add(tempBlock);
            }
            var intPlain = new List<int>();
            foreach (var intPlainBlock in intCipherBlocks)
            {
                intPlain.AddRange(DecryptBlock(intPlainBlock, key));
            }
            return intPlain;
        }

        private IEnumerable<int> DecryptBlock(IEnumerable<int> input, HillCipherKey key)
        {
            if (input.Count() != key.Key.ColumnCount)
                throw new ArgumentException("Input must have same length as key's height and width.");
            var matrixBuilder = Matrix<double>.Build;
            var matrixCipher = matrixBuilder.DenseOfRowArrays(new[] {input.Select(g => (double)g).ToArray()});
            var matrixC = matrixCipher * key.InverseKey;
            if (matrixC.RowCount != 1)
                throw new Exception("There should be only one row.");
            var intPlain = matrixC.Row(1);
            var integerConverter = new IntegerModulo(key.Modulo, 0);
            for (int i = 0; i < intPlain.Count; i++)
            {
                integerConverter.Value = (int)intPlain[i];
                intPlain[i] = integerConverter.Value;
            }
            return intPlain.Select(g => (int)g);
        }
    }
}
