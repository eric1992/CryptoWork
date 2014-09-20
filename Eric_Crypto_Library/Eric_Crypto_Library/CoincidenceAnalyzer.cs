using System.Collections.Generic;

namespace Eric_Crypto_Library
{
    public class CoincidenceAnalyzer
    {
        public string Text;

        public double IndexFor(int keylength)
        {
            var ArrayOfText = Text.ToCharArray();
            List<char> subText;
            double currentIndex = 0;
            for (int i = 0; i < keylength; i++)
            {
                subText = new List<char>();
                for (int j = i; j < Text.Length; j += keylength)
                {
                    subText.Add(ArrayOfText[j]);
                }
                currentIndex += IndexForString(new string(subText.ToArray()));
            }
            currentIndex /= keylength;
            return currentIndex;
        }

        public double IndexForString(string input)
        {
            var analyzer = new CharacterAnalyzer();
            analyzer.Text = input;
            double index = 0.0;
            foreach (var characterCount in analyzer.CharacterCounts)
            {
                index += characterCount.Value * (characterCount.Value - 1);
            }
            index /= (analyzer.TotalCharacters * (analyzer.TotalCharacters - 1));
            return index;
        }

        public Dictionary<int, CharacterAnalyzer> FreqOnNSubs(int n)
        {

            var ArrayOfText = Text.ToCharArray();
            List<char> subText;
            var returnDict = new Dictionary<int, CharacterAnalyzer>();
            for (int i = 0; i < n; i++)
            {
                subText = new List<char>();
                for (int j = i; j < Text.Length; j += n)
                {
                    subText.Add(ArrayOfText[j]);
                }
                returnDict.Add(i + 1, new CharacterAnalyzer{Text = subText});
            }
            return returnDict;
        }
    }
}
