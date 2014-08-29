using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eric_Crypto_Library
{
    public class SubstitutionCipher : ICryptoSystem<IEnumerable<char>, IEnumerable<char>, SubstitutionCipherKey>  
    {
        private static readonly char[] PossiblePlainText = 
        { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        private static readonly char[] PossibleCipherText = 
        { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        public IEnumerable<char> GetPlainText()
        {
            return PossiblePlainText;
        }

        public IEnumerable<char> GetCipherText()
        {
            return PossibleCipherText;
        }

        public IEnumerator<SubstitutionCipherKey> GetPossibleKeys()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<char> Encrypt(IEnumerable<char> input, SubstitutionCipherKey key)
        {
            var intEncrypt = Encrypt(input.Select(CharToIntConverter.Convert), key);
            return intEncrypt.Select(CharToIntConverter.Convert);
        }

        public IEnumerable<char> Decrypt(IEnumerable<char> input, SubstitutionCipherKey key)
        {
            var intEncrypt = Decrypt(input.Select(CharToIntConverter.Convert), key);
            return intEncrypt.Select(CharToIntConverter.Convert);
        }


        public IEnumerable<int> Encrypt(IEnumerable<int> input, SubstitutionCipherKey key)
        {
            if (input.Any(g => g < 0 || g > 25))
                return null;
            return new LinkedList<int>(input.Select(g => key.PlainToCipher[g]));
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
                throw new ArgumentException("Can not pass null substitutions or substitutions that do not have 26 defined substitution.");
            var orderedKeys = substitutions.Keys.OrderBy(g => g).ToList();
            for (var i = 0; i < orderedKeys.Count(); i++)
            {
                if(orderedKeys[i] != i)
                    throw new ArgumentException("The proposed substitutions are not valid. Check that all plain texts are defined.");
            }
            var orderedValues = substitutions.Values.OrderBy(g => g).ToList();
            for (var i = 0; i < orderedValues.Count(); i++)
            {
                if (orderedValues[i] != i)
                    throw new ArgumentException("The proposed substitutions are not valid. Check that the substitution makes onto the cipher text.");
            }
            _substitutions = substitutions;
        }

        public IEnumerator<IKey> GetEnumerator()
        {
            return new SubstitutionKeyEnumerator();
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class SubstitutionKeyEnumerator : IEnumerator<SubstitutionCipherKey>
        {

            public SubstitutionKeyEnumerator()
            {
                var initialSubstitution = new Dictionary<int, int>
                {
                    {0, 0},
                    {1, 1},
                    {2, 2},
                    {3, 3},
                    {4, 4},
                    {5, 5},
                    {6, 6},
                    {7, 7},
                    {8, 8},
                    {9, 9},
                    {10, 10},
                    {11, 11},
                    {12, 12},
                    {13, 13},
                    {14, 14},
                    {15, 15},
                    {16, 16},
                    {17, 17},
                    {18, 18},
                    {19, 19},
                    {20, 20},
                    {21, 21},
                    {22, 22},
                    {23, 23},
                    {24, 24},
                    {25, 25}
                };
                Current = new SubstitutionCipherKey(initialSubstitution);
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }

            public SubstitutionCipherKey Current { get; private set; }

            object IEnumerator.Current
            {
                get { return Current; }
            }
        }
    }
}
