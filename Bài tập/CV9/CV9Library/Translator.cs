using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV9Library
{
    public class ENCZTranslator
    {
        private Dictionary<string, string> dict = new Dictionary<string, string>();

        public ENCZTranslator()
        {
            dict.Add("I", "JÁ");
            dict.Add("LIKE", "MÁM RÁD");
            dict.Add("AND", "A");
            dict.Add("OR", "NEBO");
            dict.Add("BEER", "PIVO");
            dict.Add("WHISKEY", "WHISKEY");
            dict.Add("CHIPS", "CHIPSY");
        }

        public string Translate(string sentence)
        {
            string[] words = sentence.ToUpper().Split(' ');
            string[] translated = new string[words.Length];

            for (int i = 0; i < words.Length; i++)
                translated[i] = dict[words[i]];

            return String.Join(" ", translated);
        }
    }
}
