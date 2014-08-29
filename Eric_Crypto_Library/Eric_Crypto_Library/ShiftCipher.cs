using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Eric_Crypto_Library
{
    public class ShiftCipher : SubstitutionCipher
    {

       // private static readonly List<ShiftCipherKey> PossibleKeys = new List<int> {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25}.Select(g => ShiftCipherKey.Parse(g)).ToList(); 


    }

    public class ShiftCipherKey : SubstitutionCipherKey
    {
        public int Shift;

        public ShiftCipherKey(Dictionary<int, int> substitutions, int shift) : base(substitutions)
        {
            Shift = shift;
        }

        public string ToString()
        {
            return Shift.ToString();
        }
    }
}
