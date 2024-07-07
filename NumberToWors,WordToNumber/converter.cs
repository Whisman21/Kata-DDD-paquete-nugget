using System.Text;
using System;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace NumberToWors_WordToNumber
{
    public class converter
    {

        public Output Result(Input input)
        {

            Output output;

            if (input.value == -1)
            {
                string error = "Invalid input";
                output = new Output(error);
                return output;
            }
            else
            {
                string result = converterN(input.value);
                output = new Output(result);
                return output;
            }

        }
        public Output ResultWN(InputWN input)
        {

            Output output;

            if (input.value == "invalid")
            {
                string error = "Invalid input";
                output = new Output(error);
                return output;
            }
            else
            {
                int result = converterW(input.value);
                output = new Output(result);
                return output;
            }

        }



        private string converterN(int entero, int level = 0, string result = "")
        {
            string[] units = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] tens = { " ", " ", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen" };
            string[] hundreds = { "", "one hundred", "two hundred", "three hundred", "four hundred", "five hundred", "six hundred", "seven hundred", "eight hundred", "nine hundred" };
            string[] order = { "", "thousand", "millions" };

            string number = "";

            int lastthree = entero % 1000;
            int Hundreds = lastthree / 100;
            int Tens = lastthree % 100;
            int ones = lastthree % 10;

            if (entero == 0 && string.IsNullOrEmpty(result))
            {
                return "zero dollars";
            }

            if (level == 1 && (Tens / 10) == 0 && Hundreds == 0)
            {
                units[1] = "";
            }

            if (level == 2 && ones == 1 && (Tens / 10) == 0 && Hundreds == 0)
            {
                order[2] = "one million";
            }

            if (Hundreds == 1 && Tens == 0 && ones == 0)
            {
                number = "one hundred";
            }
            else
            {
                number = hundreds[Hundreds] + " ";

                if (Tens > 9 && Tens < 16)
                {
                    number = number + tens[Tens] + " ";
                }
                else if ((Tens / 10) == 2 && Tens % 10 == 0)
                {
                    number = number + "twenty";
                }
                else
                {
                    number = number + tens[Tens / 10] + " ";
                    if ((Tens / 10) > 2 && ones != 0)
                    {
                        number = number + units[ones];
                    }
                    else
                    {
                        number = number + units[ones];
                    }
                }
            }

            if ((ones != 0 || (Tens / 10) != 0 || Hundreds != 0) && level > 0)
            {
                number = number + " " + order[level] + " ";
            }

            result = number + result;

            if ((entero / 1000) > 0)
            {
                return converterN(entero / 1000, level + 1, result);
            }
            else
            {
                result = result + " dollars";

                result = result.Replace("  ", " ").Trim();

                return result;
            }


        }


        private int converterW(string input)
        {
            int[] numbers = { 0,
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
            11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
            30, 40, 50, 60, 70, 80, 90, 100,
            200, 300, 400, 500, 600, 700, 800, 900,
            1000, 1000000, 1000000
            };

            string[] words = { "zero",
            "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
            "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen", "twenty",
            "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"
             };

            List<string> wordList = new List<string>(input.Split(' '));
            int number = 0;
            int aux = 0;

            for (int i = 0; i < wordList.Count; i++)
            {
                string word = wordList[i];
                string? next = i + 1 < wordList.Count ? wordList[i + 1] : null;

                if (word == "dollars" || word == "thousand" || word == "millions" || word == "million" || word == "hundred")
                {
                    continue;
                }

                for (int j = 0; j < 28; j++)
                {
                    if (word == words[j])
                    {
                        aux += numbers[j];
                        break;
                    }
                }

                if (next == "hundred")
                {
                    aux *= 100;
                }
                else if (next == "thousand")
                {
                    aux *= 1000;
                    number += aux;
                    aux = 0;
                }
                else if (next == "millions" || next == "million")
                {
                    aux *= 1000000;
                    number += aux;
                    aux = 0;
                }
            }

            number += aux;

            return number;
        }
    }
}


