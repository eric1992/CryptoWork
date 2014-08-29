using System.Collections;
using System.Collections.Generic;

namespace Eric_Crypto_Library
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="I">Specifies the type of the plain text of the cryptosystem</typeparam>
    /// <typeparam name="O">Specifies the type of the cipher text of the cryptosystem</typeparam>
    public interface ICryptoSystem<I, O, K> where K : IKey
    {
        IEnumerable<I> GetPlainText();
        IEnumerable<O> GetCipherText();
        IEnumerator GetPossibleKeys();
        IEnumerable<O> Encrypt(IEnumerable<I> input, K key);
        IEnumerable<I> Decrypt(IEnumerable<I> input, K key);
    }
}