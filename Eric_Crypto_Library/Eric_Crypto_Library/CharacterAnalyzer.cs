using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace Eric_Crypto_Library
{
    /// <summary>
    /// Used to perform relative frequency analysis on a given char enumerable
    /// </summary>
    public class CharacterAnalyzer
    {
        private IEnumerable<char> _text;
        public IEnumerable<char> Text
        {
            get { return _text; }
            //Updates both the text and the relative frequencies.
            set
            {
                if(value == null)
                    throw new ArgumentException("");
                _text = value;
                CharacterCounts = new Dictionary<char, int>();
                //Increments the count of the given char or adds it to the dictionary if it is not in it.
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

        public Dictionary<string, int> DiagramCount
        {
            get
            {
                var textAsString = new string(_text.ToArray());
                var count = new Dictionary<string, int>();

                for (int i = 0; i < _text.Count()- 1; i++)
                {
                    var diagram = textAsString.Substring(i, 2);
                    if (count.ContainsKey(diagram))
                    {
                        count[diagram]++;
                    }
                    else
                    {
                        count.Add(diagram, 1);
                    }
                }
                count = count.OrderByDescending(g => g.Value).ToDictionary(g => g.Key, g => g.Value);
                return count;
            }
        }

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
