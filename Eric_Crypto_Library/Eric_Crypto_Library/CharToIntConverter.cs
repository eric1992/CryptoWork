using System.Collections.Generic;
using System.Linq;

namespace Eric_Crypto_Library
{
    /// <summary>
    /// Used to convert char in a-z to int in 0-25
    /// </summary>
    public class CharToIntConverter
    {
        /// <summary>
        /// Maps chars to the appropriate int repesentation.
        /// </summary>
        public static Dictionary<char, int> Mappings = new Dictionary<char, int>()
        {
            {'a', 0},
            {'b', 1},
            {'c', 2},
            {'d', 3},
            {'e', 4},
            {'f', 5},
            {'g', 6},
            {'h', 7},
            {'i', 8},
            {'j', 9},
            {'k', 10},
            {'l', 11},
            {'m', 12},
            {'n', 13},
            {'o', 14},
            {'p', 15},
            {'q', 16},
            {'r', 17},
            {'s', 18},
            {'t', 19},
            {'u', 20},
            {'v', 21},
            {'w', 22},
            {'x', 23},
            {'y', 24},
            {'z', 25}
        };

        public static int Convert(char input)
        {
            return Mappings[input];
        }

        public static char Convert(int input)
        {
            return Mappings.First(kp => kp.Value == input).Key;
        }
    }
}
