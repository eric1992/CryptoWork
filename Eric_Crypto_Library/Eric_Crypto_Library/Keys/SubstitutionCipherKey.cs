using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eric_Crypto_Library.Keys.Enumerators;

namespace Eric_Crypto_Library
{
    public class SubstitutionCipherKey : IKey
    {
        public Dictionary<int, int> PlainToCipher
        {
            get { return _substitutions; }
            protected set { _substitutions = value; }
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

        
    }
}