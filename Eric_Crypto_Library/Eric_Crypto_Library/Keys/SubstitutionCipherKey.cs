using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eric_Crypto_Library.Keys
{
    /// <summary>
    /// A Key used in the substitution cipher.
    /// </summary>
    public class SubstitutionCipherKey : IKey
    {
        /// <summary>
        /// Maps a given plain text int to its cipher text int.
        /// </summary>
        public Dictionary<int, int> PlainToCipher
        {
            get { return _substitutions; }
            protected set { _substitutions = value; }
        }

        private Dictionary<int, int> _substitutions;

        /// <summary>
        /// Basic Constructor.
        /// </summary>
        /// <param name="substitutions">A dictionary of intended mappings</param>
        public SubstitutionCipherKey(Dictionary<int, int> substitutions)
        {
            if(substitutions == null || substitutions.Count != 26)
                throw new ArgumentException("Can not pass null substitutions or substitutions that do not have 26 defined substitution.");
            var orderedKeys = substitutions.Keys.OrderBy(g => g).ToList();
            //Check that the key is valid
            for (var i = 0; i < orderedKeys.Count(); i++)
            {
                if(orderedKeys[i] != i)
                    throw new ArgumentException("The proposed substitutions are not valid. Check that all plain texts are defined.");
            }
            var orderedValues = substitutions.Values.OrderBy(g => g).ToList();
            //checks that all the values are valid
            for (var i = 0; i < orderedValues.Count(); i++)
            {
                if (orderedValues[i] != i)
                    throw new ArgumentException("The proposed substitutions are not valid. Check that the substitution makes onto the cipher text.");
            }
            _substitutions = substitutions;
        }

        public override string ToString()
        {
            if (_substitutions == null) 
                return "";
            var outString = new StringBuilder();
            foreach (var i in _substitutions)
            {
                outString.Append(i.Value + ",");
            }
            return outString.ToString(0, outString.Length - 1);
        }

        
    }
}