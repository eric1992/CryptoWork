using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eric_Crypto_Library
{
    public class CharacterAnalyzer
    {
        private IEnumerable<char> _text;
        public IEnumerable<char> Text
        {
            get { return _text; }
            set
            {
                if(value == null)
                    throw new ArgumentException("");
                _text = value;
                CharacterCounts = new Dictionary<char, int>();
                foreach (var currentChar in value)
                {
                    try
                    {
                        CharacterCounts[currentChar]++;
                    }
                    catch (Exception)
                    {
                        CharacterCounts.Add(currentChar, 1);
                    }
                }
            }
        }

        public Dictionary<char, int> CharacterCounts;

        public CharacterAnalyzer()
        {
            CharacterCounts = new Dictionary<char, int>();
        }

        public int TotalCharacters
        {
            get { return Text.Count(); }
        }

        public override string ToString()
        {
            var returnString = new StringBuilder("The Counts:");
            foreach (var characterCount in CharacterCounts)
            {
                returnString.Append("\n(" + characterCount.Key + ", " + characterCount.Value + ", " + ((double)characterCount.Value)/((double)TotalCharacters) + ")");
            }
            return returnString.ToString();
        }
    }
}
