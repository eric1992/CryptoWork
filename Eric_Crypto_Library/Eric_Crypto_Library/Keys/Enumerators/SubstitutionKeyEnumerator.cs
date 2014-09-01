using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eric_Crypto_Library.Keys.Enumerators
{
    public class SubstitutionKeyEnumerator : IEnumerator<SubstitutionCipherKey>
    {

        public SubstitutionKeyEnumerator()
        {
            var initialSubstitution = new Dictionary<int, int>
            {
                {0, 0},
                {1, 1},
                {2, 2},
                {3, 3},
                {4, 4},
                {5, 5},
                {6, 6},
                {7, 7},
                {8, 8},
                {9, 9},
                {10, 10},
                {11, 11},
                {12, 12},
                {13, 13},
                {14, 14},
                {15, 15},
                {16, 16},
                {17, 17},
                {18, 18},
                {19, 19},
                {20, 20},
                {21, 21},
                {22, 22},
                {23, 23},
                {24, 24},
                {25, 25}
            };
            Current = new SubstitutionCipherKey(initialSubstitution);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        object IEnumerator.Current { get { return Current; } }

        public SubstitutionCipherKey Current { get; private set; }

    }
}