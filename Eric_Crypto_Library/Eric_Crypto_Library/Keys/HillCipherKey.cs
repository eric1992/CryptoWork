using System;
using MathNet.Numerics.LinearAlgebra;

namespace Eric_Crypto_Library.Keys
{
    public class HillCipherKey : IKey
    {
        public int Modulo { get; private set; }

        public int Dimension
        {
            get { return _key.ColumnCount; }
        }

        private Matrix<double> _key;

        public Matrix<double> Key
        {
            get { return _key; }
            set
            {
                if(value == null)
                    throw new ArgumentException("Can't make the key null.");
                if (value.ColumnCount != value.RowCount)
                    throw new ArgumentException("Key must be a square matrix.");
                var determinate = new IntegerModulo(Modulo, (int)value.Determinant());
                if (determinate.Inverse() == null)
                {
                    throw new ArgumentException("Can't have key without inverse mod " + Modulo);
                }
                _key = value;
            }
        }

        public Matrix<double> InverseKey
        {
            get
            {
                var trueInverse = _key.Inverse();
                trueInverse *= _key.Determinant();
                var determinantInverseMod = new IntegerModulo(Modulo, ((int)_key.Determinant()));
                trueInverse *= determinantInverseMod.Value;
                return trueInverse.Map(g => (double)(new IntegerModulo(Modulo, ((int)g)).Value));
            }
        } 

        public HillCipherKey(int modulo, Matrix<double > input)
        {
            if(modulo < 1)
                throw new ArgumentException("Can't have a negative or 0 modulo");
            _key = input;
            Modulo = modulo;
        }
    }
}
