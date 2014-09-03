using System;
using System.Collections.Generic;

namespace Eric_Crypto_Library.Keys
{
    /// <summary>
    /// A Key for the shift cipher, extends the substitution key.
    /// </summary>
    public class ShiftCipherKey : SubstitutionCipherKey
    {
        private int _shift;

        public int Shift
        {
            get { return _shift; }
            //Checks the value it is set to and updates the substitutions.
            set { 
                if(value < 0 || value > 25)
                    throw new ArgumentOutOfRangeException("Value must be between 0 and 25 inclusive.");
                PlainToCipher = ShiftToSubstitution(value);;
                _shift = value;
            }
        }

        /// <summary>
        /// Sets up the key and substitutions
        /// </summary>
        /// <param name="shift">the desired shift in the cipher</param>
        public ShiftCipherKey(int shift)
            //calls the base constructor with a dictionary constructed from the shift
            : base(ShiftToSubstitution(shift))
        {
            Shift = shift;
        }

        public override string ToString()
        {
            return Shift.ToString();
        }
        
        /// <summary>
        /// Constructs a dictionary of substitutions from a given shift.
        /// </summary>
        /// <param name="shift"></param>
        /// <returns></returns>
        private static Dictionary<int, int> ShiftToSubstitution(int shift)
        {
            if(shift < 0 || shift > 25)
                throw new ArgumentException("Shifts must me between 0 and 25 inclusive.");
            var returnDiction = new Dictionary<int, int>();
            for (int i = 0; i < 26; i++)
            {
                returnDiction.Add(i, (i + shift) % 26);
            }
            return returnDiction;
        }

        


    }
}