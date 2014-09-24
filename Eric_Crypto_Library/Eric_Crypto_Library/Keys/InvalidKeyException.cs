using System;

namespace Eric_Crypto_Library
{
    class InvalidKeyException : Exception
    {
        public InvalidKeyException(string message) : base(message)
        {
            
        }
    }
}
