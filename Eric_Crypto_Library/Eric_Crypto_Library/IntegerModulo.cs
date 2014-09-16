using System;
using MathNet.Numerics;

namespace Eric_Crypto_Library
{
    public class IntegerModulo
    {
        private int _modulo;

        public int Modulo
        {
            get { return _modulo; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Cannot have a negative or zero modulo");
                }
                _modulo = value;
            }
        }

        private int _value;

        public int Value
        {
            get { return _value; }
            set
            {
                var current = value;
                if (current < 0)
                {
                    do
                    {
                        current = _modulo + current;
                    } while (current < 0);
                    _value = current;
                }
                else
                {
                    _value = current % _modulo;
                }
            }
        }

        public IntegerModulo(int modulo, int value)
        {
            Modulo = modulo;
            Value = value;
        }


        public static IntegerModulo operator +(IntegerModulo a, IntegerModulo b)
        {
            if(a.Modulo != b.Modulo)
                throw new Exception("Cannot add IntegerModulos of different modulos.");
            return new IntegerModulo(a.Modulo, a.Value+b.Value);
        }

        public static IntegerModulo operator *(IntegerModulo a, IntegerModulo b)
        {
            if (a.Modulo != b.Modulo)
                throw new Exception("Cannot multiply IntegerModulos of different modulos.");
            return new IntegerModulo(a.Modulo, a.Value * b.Value);
        }

        public static IntegerModulo operator -(IntegerModulo a, IntegerModulo b)
        {
            if (a.Modulo != b.Modulo)
                throw new Exception("Cannot add IntegerModulos of different modulos.");
            return new IntegerModulo(a.Modulo, a.Value - b.Value);
        }

        public IntegerModulo Inverse()
        {
            if (Euclid.GreatestCommonDivisor(Value, Modulo) != 1)
            {
                return null;
            }
            for (var i = new IntegerModulo(Modulo, 1); i.Value <= Modulo; i.Value++)
            {
                if ((i*this).Value == 1)
                    return i;
            }
            return null;
        }
    }
}
