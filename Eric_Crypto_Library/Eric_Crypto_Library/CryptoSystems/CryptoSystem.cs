using System.Collections;
using System.Collections.Generic;

namespace Eric_Crypto_Library
{
    /// <summary>
    /// A generic interface for a cryptosystem.
    /// 
    /// Follows the mathematically definitions and uses generics to achieve abstractions.
    /// </summary>
    /// <typeparam name="Plain">Specifies the type of the plain text of the cryptosystem</typeparam>
    /// <typeparam name="Cipher">Specifies the type of the cipher text of the cryptosystem</typeparam>
    /// <typeparam name="Key">Specifies the key for type for the system.</typeparam>
    public interface ICryptoSystem<Plain, Cipher, Key> where Key : IKey
    {
        /// <summary>
        /// Gets all the possible plain text units.
        /// </summary>
        Plain GetPlainText();
        /// <summary>
        /// Gets all the possible cipher text unit.s;2
        /// </summary
        Cipher GetCipherText();
        /// <summary>
        /// Returns an enumerator over all the possible keys for this crypto system.
        /// </summary>
        IEnumerator<Key> GetPossibleKeys();
        /// <summary>
        /// Encrypts the giving plain text to the given key.
        /// </summary>
        /// <param name="input">The given plain text.</param>
        /// <param name="key">The given key for the text.</param>
        /// <returns>The output of the encryption function</returns>
        Cipher Encrypt(Plain input, Key key);
        Plain Decrypt(Plain input, Key key);
    }
}