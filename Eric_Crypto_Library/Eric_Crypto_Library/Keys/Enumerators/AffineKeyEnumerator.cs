using System.Collections;
using System.Collections.Generic;

namespace Eric_Crypto_Library.Keys.Enumerators
{
    public class AffineKeyEnumerator : IEnumerator<AffineCipherKey>
    {
        public AffineKeyEnumerator()
        {
            Current = new AffineCipherKey(1, 0);
        }

        public void Dispose()
        {
            Current = null;
        }

        public bool MoveNext()
        {
            if (Current.A == 25 && Current.B == 25)
                return false;
            if (Current.B < 25)
            {
                Current.B++;
                return true;
            }
            if (Current.B == 25)
            {
                if(Current.A == 11)
                    Current.SetAB(15, 0);
                else
                    Current.SetAB(Current.A + 2, 0);
            }
            return true;
        }

        public void Reset()
        {
            Current.SetAB(1, 0);
        }

        public AffineCipherKey Current { get; private set; }

        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
}
