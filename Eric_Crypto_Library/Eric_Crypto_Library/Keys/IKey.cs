using System.Collections.Generic;

namespace Eric_Crypto_Library.Keys
{
    /// <summary>
    /// An IKey be enumerable over itself.
    /// </summary>
    public interface IKey: IEnumerable<IKey>
    { 
    }
}
