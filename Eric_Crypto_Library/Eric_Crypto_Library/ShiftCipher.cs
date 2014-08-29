using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Eric_Crypto_Library
{
    public class ShiftCipher : SubstitutionCipher, ICryptoSystem<IEnumerable<char>, IEnumerable<char>, ShiftCipherKey>
    {
        IEnumerator<ShiftCipherKey> ICryptoSystem<IEnumerable<char>, IEnumerable<char>, ShiftCipherKey>.GetPossibleKeys()
        {
            return new ShiftCipherKey.ShiftKeyEnumerator();
        }

        public IEnumerable<char> Encrypt(IEnumerable<char> input, ShiftCipherKey key)
        {
            var intEncrypt = Encrypt(input.Select(CharToIntConverter.Convert), key);
            return intEncrypt.Select(CharToIntConverter.Convert);
        }

        public IEnumerable<char> Decrypt(IEnumerable<char> input, ShiftCipherKey key)
        {
            var intDecrypt = Decrypt(input.Select(CharToIntConverter.Convert), key);
            return intDecrypt.Select(CharToIntConverter.Convert);
        }
    }

    public class ShiftCipherKey : SubstitutionCipherKey
    {
        public int Shift;

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
                returnDiction.Add(i, i + shift);
            }
            return returnDiction;
        }

        public class ShiftKeyEnumerator : IEnumerator<ShiftCipherKey>
        {
            public ShiftKeyEnumerator()
            {
                Current = new ShiftCipherKey(0);
            }

            public void Dispose()
            {
                Current = null;
            }

            public bool MoveNext()
            {
                if (Current.Shift < 25)
                {
                    Current.Shift++;
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                Current.Shift = 0;
            }

            public ShiftCipherKey Current { get; private set; }

            object IEnumerator.Current
            {
                get { return Current; }
            }
        }


    }
}
