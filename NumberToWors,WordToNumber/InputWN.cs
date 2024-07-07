using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWors_WordToNumber
{
    public class InputWN
    {

        public string value { get; }

       private string Validate(string input)
        {
            string[] words = {
            "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
            "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen", "twenty",
            "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"
            };
            
            List<string> wordList = new List<string>(input.Split(' '));
            for (int i = 0; i < wordList.Count; i++)
            {
                string word = wordList[i];
                int aux = 0;
                if (word == "dollars" || word == "thousand" || word == "millions" || word == "million" || word == "hundred")
                {
                    continue;
                }

                for (int e = 0; e < 28; e++)
                {
                    if (word == words[e])
                    {
                        break;
                    }
                    aux++;
                }

                if (aux == 28)
                {
                    return "invalid";
                }

            }

            return input;

        }
        public InputWN(String input)
        {
            value = Validate(input);

        }
    }
}
