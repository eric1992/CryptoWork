using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eric_Crypto_Library
{
    class InvalidKeyException : Exception
    {
        public InvalidKeyException(string message) : base(message)
        {
            
        }
    }
}
