using System;
using MathNet.Numerics.LinearAlgebra;

namespace Eric_Crypto_Library.Keys
{
    class HillCipherKey : IKey
    {
        private int _modulo;

        private Matrix<int> _key;

        public Matrix<int> Key
        {
            get { return _key; }
            set
            {
                if(value == null)
                    throw new ArgumentException("Can't make the key null.");
                var determinate = new IntegerModulo(_modulo, value.Determinant());
                if (determinate.Inverse() == null)
                {
                    throw new ArgumentException("Can't have key without inverse mod " + _modulo);
                }
                _key = value;
            }
        }

        public HillCipherKey(int modulo, Matrix<int> input)
        {
            if(modulo < 1)
                throw new ArgumentException("Can't have a negative or 0 modulo");
            _key = input;
            _modulo = modulo;
        }
    }
}
