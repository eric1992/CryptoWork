using System.Collections;
using System.Collections.Generic;

namespace Eric_Crypto_Library
{
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