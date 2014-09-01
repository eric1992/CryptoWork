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
            return new ShiftKeyEnumerator();
        }

        public IEnumerable<char> Encrypt(IEnumerable<char> input, ShiftCipherKey key)
        {
            var intInput = input.Select(CharToIntConverter.Convert);
            var intEncrypt = Encrypt(intInput, key);
            var plainOutput = intEncrypt.Select(CharToIntConverter.Convert);
            return plainOutput;
        }

        public IEnumerable<char> Decrypt(IEnumerable<char> input, ShiftCipherKey key)
        {
            var intInput = input.Select(CharToIntConverter.Convert);
            var intDecrypt = Decrypt(intInput, key);
            var plainOutput = intDecrypt.Select(CharToIntConverter.Convert);
            return plainOutput;
        }
    }

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
                Current.Shift = Current.Shift + 1;
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
