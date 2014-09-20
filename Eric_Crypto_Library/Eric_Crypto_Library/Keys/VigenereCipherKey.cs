using System.Collections.Generic;

namespace Eric_Crypto_Library.Keys
{
    public class VigenereCipherKey : PolyAlphabeticCipherKey
    {
        public VigenereCipherKey(IEnumerable<ShiftCipherKey> keys)
        {
            foreach (var shiftCipherKey in keys)
            {
                AddKey(shiftCipherKey);
            }
        }
    }
}