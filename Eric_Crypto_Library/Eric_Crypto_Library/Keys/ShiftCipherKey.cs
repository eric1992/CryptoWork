using System;
using System.Collections.Generic;

namespace Eric_Crypto_Library.Keys
{
    public class ShiftCipherKey : SubstitutionCipherKey
    {
        private int _shift;

        public int Shift
        {
            get { return _shift; }
            set { 
                if(value < 0 || value > 25)
                    throw new ArgumentOutOfRangeException("Value must be between 0 and 25 inclusive.");
                PlainToCipher = ShiftToSubstitution(value);
                _shift = value;
            }
        }

        public ShiftCipherKey(int shift)
            : base(ShiftToSubstitution(shift))
        {
            Shift = shift;
        }

        public override string ToString()
        {
            return Shift.ToString();
        }

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