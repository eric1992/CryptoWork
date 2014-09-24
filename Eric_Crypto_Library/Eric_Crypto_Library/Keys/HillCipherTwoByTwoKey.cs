using System;
using System.Collections.Generic;

namespace Eric_Crypto_Library.Keys
{
    public class HillCipherTwoByTwoKey : IKey
    {
        public IntegerModulo A, B, C, D;


        public HillCipherTwoByTwoKey(int a, int b, int c, int d)
        {
            A = new IntegerModulo(26, a);
            B = new IntegerModulo(26, b);
            C = new IntegerModulo(26, c);
            D = new IntegerModulo(26, d);
        }

        /// <summary>
        /// Creates a key of the form
        /// |a b|
        /// |c d|
        /// </summary>
        public HillCipherTwoByTwoKey(IntegerModulo a, IntegerModulo b, IntegerModulo c, IntegerModulo d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }

        public HillCipherTwoByTwoKey Inverse
        {
            get
            {
                var twentyFive = new IntegerModulo(26, 25);
                var inverseDet = new IntegerModulo(26, A.Value*D.Value - B.Value*C.Value).Inverse();
                var newA = inverseDet*D;
                var newB = twentyFive*inverseDet*B;
                var newC = twentyFive*inverseDet*C;
                var newD = inverseDet*A;
                var keyInverse = new HillCipherTwoByTwoKey(newA, newB, newC, newD);
                return keyInverse;
            }
        }

        public static List<IntegerModulo> operator *(List<IntegerModulo> a, HillCipherTwoByTwoKey B)
        {
            if(a == null || B == null || a.Count != 2)
                throw  new ArgumentException("Check your arguements, must be a non null two element list and a valid key");
            var computedList = new List<IntegerModulo>{a[0]*B.A+a[1]*B.C, a[0]*B.B+a[1]*B.D};
            return computedList;
        }


    }
}
    