using System.Collections;
using System.Collections.Generic;

namespace Eric_Crypto_Library
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="Plain">Specifies the type of the plain text of the cryptosystem</typeparam>
    /// <typeparam name="Cipher">Specifies the type of the cipher text of the cryptosystem</typeparam>
    /// <typeparam name="Key">Specifies the key for type for the system.</typeparam>
    public interface ICryptoSystem<Plain, Cipher, Key> where Key : IKey
    {
        Plain GetPlainText();
        Cipher GetCipherText();
        IEnumerator<Key> GetPossibleKeys();
        Cipher Encrypt(Plain input, Key key);
        Plain Decrypt(Plain input, Key key);
    }
}