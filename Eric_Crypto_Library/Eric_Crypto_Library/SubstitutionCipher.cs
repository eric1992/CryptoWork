using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eric_Crypto_Library
{
    public class SubstitutionCipher : ICryptoSystem
    {
        private static readonly int[] PossiblePlainText = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 };
        private static readonly int[] PossibleCipherText = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 };

        public IEnumerable<char> GetPlainText()
        {
            return PossiblePlainText.Select(i => i.ToString().ToCharArray()[0]);
        }

        public IEnumerable<char> GetCipherText()
        {
            return PossibleCipherText.Select(i => i.ToString().ToCharArray()[0]);
        }

        public IEnumerator<IKey> GetPossibleKeys()
        {
            // var Keys = new List<>
            throw new NotImplementedException();
        }
        
        public IEnumerable<char> Encrypt(IEnumerable<char> input, IKey key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> Encrypt(IEnumerable<int> input, SubstitutionCipherKey key)
        {
            if (input.Any(g => g < 0 || g > 25))
                return null;
            return new LinkedList<int>(input.Select(g => key.PlainToCipher[g]));
        }

        public IEnumerable<char> Decrypt(IEnumerable<char> input, IKey key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> Decrypt(IEnumerable<int> input, SubstitutionCipherKey key)
        {
            if (input.Any(g => g < 0 || g > 25))
                return null;
            return new LinkedList<int>(input.Select(g => key.PlainToCipher.First(keyPair => keyPair.Value == g).Key));
        }
    }

    public class SubstitutionCipherKey : IKey
    {
        public Dictionary<int, int> PlainToCipher
        {
            get { return _substitutions; }
            private set { _substitutions = value; }
        }

        private Dictionary<int, int> _substitutions;


        public SubstitutionCipherKey(Dictionary<int, int> substitutions)
        {
            if(substitutions == null || substitutions.Count != 26)
                return;
            var orderedKeys = substitutions.Keys.OrderBy(g => g).ToList();
            for (var i = 0; i < substitutions.Count(); i++)
            {
                if(orderedKeys[i] != i)
                    return;
            }
            _substitutions = substitutions;
        }

        public override string ToString()
        {
            if (_substitutions == null)
                return null;
            var outString = new StringBuilder();
            foreach (var i in _substitutions)
            {
                outString.Append(i.Value + ",");
            }
            return outString.ToString(0, outString.Length - 1);
        }
    }
}
