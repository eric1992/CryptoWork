using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Eric_Crypto_Library.Keys.Enumerators;

namespace Eric_Crypto_Library.Keys
{
    /// <summary>
    /// Defines an affine cipher, based of the substution cipher.
    /// </summary>
    public class AffineCipherKey : SubstitutionCipherKey
    {
        private int _a;
        private int _b;

        public int A
        {
            get { return _a; }
            //Sets and performs checks on the desired a, also updates the substitutions
            set
            {
                if(value <= 0 || value % 2 == 0 || value == 13)
                    throw new ArgumentException("Must be positive, non even, and not 13");
                _a = value;
                PlainToCipher = GenerateSubstitutions(_a, _b);
            }
        }

        public int B
        {
            get { return _b; }
            //Sets and performs checks on the desired b, also updates the substitutions
            set
            {
                if(value < 0 || value > 25)
                    throw new ArgumentException("Must be between 0 and 25 inclusive.");
                _b = value;
                PlainToCipher = GenerateSubstitutions(_a, _b);
            }
        }

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="a">The desired a</param>
        /// <param name="b">The desired b</param>
        public AffineCipherKey(int a, int b)
            : base(GenerateSubstitutions(a,b))
        {
            _a = a;
            _b = b;
        }

        /// <summary>
        /// Provides a method to update a and b without updating the substitution list twice.
        /// </summary>
        public void SetAB(int a, int b)
        {
            if (a <= 0 || a % 2 == 0 || a == 13 || b > 25 || b < 0)
                throw new ArgumentException("a must not be even or 13 and 0<=b<=25");
            _a = a;
            _b = b;
            PlainToCipher = GenerateSubstitutions(_a, _b);
        }

        public new IEnumerator<IKey> GetEnumerator()
        {
            return new AffineKeyEnumerator();
        }

        /// <summary>
        /// Generates substitutions from a given a and b.
        /// </summary>
        private static Dictionary<int, int> GenerateSubstitutions(int a, int b)
        {
            if(a <= 0 || a % 2 == 0 || a == 13 || b > 25 || b < 0)
                throw new ArgumentException("a must not be even or 13 and 0<=b<=25");
            var returnDictionary = new Dictionary<int, int>(26);
            int cipheredValue;
            for (int i = 0; i < 26; i++)
            {
                cipheredValue = (a*i + b)%26;
                returnDictionary.Add(i, cipheredValue);
            }
            return returnDictionary;
        }
    }
}
