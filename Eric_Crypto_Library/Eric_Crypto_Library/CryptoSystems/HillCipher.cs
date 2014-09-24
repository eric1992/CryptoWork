using System;
using System.Collections.Generic;
using System.Linq;
using Eric_Crypto_Library.Keys;

namespace Eric_Crypto_Library.CryptoSystems
{
    public class HillCipherTwoByTwo : ICryptoSystem<IEnumerable<char>, IEnumerable<char>, HillCipherTwoByTwoKey>
    {

        public IEnumerable<char> Encrypt(IEnumerable<char> input, HillCipherTwoByTwoKey key)
        {
            var intPlain = input.Select(CharToIntConverter.Convert);
            var intCipher = Encrypt(intPlain, key);
            var charCipher = intCipher.Select(CharToIntConverter.Convert);
            return charCipher;

        }

        private IEnumerable<int> Encrypt(IEnumerable<int> input, HillCipherTwoByTwoKey key)
        {
            var intPlain = new List<int>(input);
            if (intPlain.Count % 2 != 0)
            {
                intPlain.Add(0);
            }
            var intPlainBlocks = new List<List<int>>();
            var tempBlock = new List<int>();
            for (var i = 0; i < intPlain.Count; i += 2)
            {
                tempBlock.Clear();
                for (var j = i; j < i + 2; j++)
                {
                    tempBlock.Add(intPlain[j]);
                }
                intPlainBlocks.Add(new List<int>(tempBlock));
            }
            var intCipher = new List<int>();
            foreach (var intPlainBlock in intPlainBlocks)
            {
                intCipher.AddRange(EncryptBlock(intPlainBlock, key));
            }
            return intCipher;
        }

        private IEnumerable<int> EncryptBlock(IEnumerable<int> input, HillCipherTwoByTwoKey key)
        {
            if(input == null || key == null)
                throw new ArgumentException("Null arguement provided");
            if(input.Count() != 2)
                throw new ArgumentException("Must act on two element lists");
            var cipherInt = (input.Select(g => new IntegerModulo(26, g)).ToList()*key).Select(g => g.Value).ToList();
            return cipherInt;
        }

        public IEnumerable<char> Decrypt(IEnumerable<char> input, HillCipherTwoByTwoKey key)
        {
            var intPlain = input.Select(CharToIntConverter.Convert);
            var intCipher = Decrypt(intPlain, key);
            var charCipher = intCipher.Select(CharToIntConverter.Convert);
            return charCipher;
        }

        private IEnumerable<int> Decrypt(IEnumerable<int> input, HillCipherTwoByTwoKey key)
        {
            var intCipher = new List<int>(input);
            if (intCipher.Count % 2 != 0)
            {
                intCipher.Add(0);
            }
            var intCipherBlocks = new List<List<int>>();
            var tempBlock = new List<int>();
            for (var i = 0; i < intCipher.Count; i += 2)
            {
                tempBlock.Clear();
                for (var j = i; j < i + 2; j++)
                {
                    tempBlock.Add(intCipher[j]);
                }
                intCipherBlocks.Add(new List<int>(tempBlock));
            }
            var intPlain = new List<int>();
            foreach (var intPlainBlock in intCipherBlocks)
            {
                intPlain.AddRange(DecryptBlock(intPlainBlock, key));
            }
            return intPlain;
        }

        private IEnumerable<int> DecryptBlock(IEnumerable<int> input, HillCipherTwoByTwoKey key)
        {
            if (input == null || key == null)
                throw new ArgumentException("Null arguement provided");
            if (input.Count() != 2)
                throw new ArgumentException("Must act on two element lists");
            var cipherInt = (input.Select(g => new IntegerModulo(26, g)).ToList() * key.Inverse).Select(g => g.Value);
            return cipherInt;
        }
    }
}
