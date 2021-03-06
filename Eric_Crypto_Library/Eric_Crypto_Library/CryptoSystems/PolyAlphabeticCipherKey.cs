﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Eric_Crypto_Library.Keys
{
    public class PolyAlphabeticCipherKey : IKey
    {
        public ICollection<SubstitutionCipherKey> Keys
        {
            get { return keys; }
            protected set { keys = value; }
        }

        private ICollection<SubstitutionCipherKey> keys;
 
        public PolyAlphabeticCipherKey()
        {
            keys = new List<SubstitutionCipherKey>();
        }

        public void AddKey(SubstitutionCipherKey input)
        {
            keys.Add(input);
        }

        public bool RemoveKey(int index)
        {
            if(index < 0 || index >= keys.Count)
                throw new IndexOutOfRangeException("Index out of bounds.");
            return keys.Remove(keys.ElementAt(index));
        }
    }
}