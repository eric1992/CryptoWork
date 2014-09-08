using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eric_Crypto_Library
{
    /// <summary>
    /// Used to perform relative frequency analysis on a given char enumerable
    /// </summary>
    public class CharacterAnalyzer
    {
        private string _text;
        public IEnumerable<char> Text
        {
            get { return _text; }
            //Updates both the text and the relative frequencies.
            set
            {
                if(value == null)
                    throw new ArgumentException("");
                _text = new string(value.ToArray());
                GramCountsList = new List<Dictionary<string, int>>();
                for (int i = 0; i < maxGramLength; i++)
                {
                    GramCountsList.Add(new Dictionary<string, int>());
                }
                Dictionary<string, int> currentGramCount;
                String currentGram;
                //Increments the count of the given char or adds it to the dictionary if it is not in it.
                for (int characterIndex = 0; characterIndex < _text.Count(); characterIndex++)
                {
                    for (int gramLength = 1; gramLength < GramCountsList.Count + 1 && characterIndex + gramLength < _text.Length; gramLength++)
                    {
                        currentGramCount = GramCountsList[gramLength - 1];
                        try
                        {
                            currentGram = _text.Substring(characterIndex, gramLength);
                            currentGramCount[currentGram]++;
                        }
                        catch (Exception)
                        {
                            currentGramCount.Add(_text.Substring(characterIndex, gramLength), 1);
                        }
                    }
                }
            }
        }

        public List<Dictionary<string, int>> GramCountsList;
        private int maxGramLength;
        public CharacterAnalyzer(int maxGramLength)
        {
            GramCountsList = new List<Dictionary<string, int>>();
            this.maxGramLength = maxGramLength;
            for (int i = 0; i < maxGramLength; i++)
            {
                GramCountsList.Add(new Dictionary<string, int>());
            }
        }

        public int TotalCharacters
        {
            get { return Text.Count(); }
        }

        public override string ToString()
        {
            var returnString = new StringBuilder("The Counts:");
            var i = 1;
            foreach (var gramList in GramCountsList)
            {
                returnString.Append("\nThe " + i++ + " gram counts.");
                foreach (var gramCount in gramList)
                {
                    returnString.Append("\n(" + gramCount.Key + ", " + gramCount.Value + ", " + ((double)gramCount.Value) / ((double)TotalCharacters) + ")");
                }
            }
            
            return returnString.ToString();
        }
    }
}
