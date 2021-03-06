﻿using System.Collections.Generic;
using System.Linq;
using Eric_Crypto_Library.Keys;
using Eric_Crypto_Library.Keys.Enumerators;

namespace Eric_Crypto_Library.CryptoSystems
{
    /// <summary>
    /// Implements a shift cipher
    /// </summary>
    public class ShiftCipher : SubstitutionCipher, ICryptoSystem<IEnumerable<char>, IEnumerable<char>, ShiftCipherKey>
    {
        IEnumerator<ShiftCipherKey> ICryptoSystem<IEnumerable<char>, IEnumerable<char>, ShiftCipherKey>.GetPossibleKeys()
        {
            return new ShiftKeyEnumerator();
        }

        public IEnumerable<char> Encrypt(IEnumerable<char> input, ShiftCipherKey key)
        {
            var intInput = input.Select(CharToIntConverter.Convert);
            //calls base class encrypt
            var intEncrypt = Encrypt(intInput, key);
            var plainOutput = intEncrypt.Select(CharToIntConverter.Convert);
            return plainOutput;
        }

        public IEnumerable<char> Decrypt(IEnumerable<char> input, ShiftCipherKey key)
        {
            var intInput = input.Select(CharToIntConverter.Convert);
            //calls base class decrypt
            var intDecrypt = Decrypt(intInput, key);
            var plainOutput = intDecrypt.Select(CharToIntConverter.Convert);
            return plainOutput;
        }
    }
}