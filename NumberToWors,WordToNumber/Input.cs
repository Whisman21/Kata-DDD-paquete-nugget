using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWors_WordToNumber
{
    public class Input
    {
        public int value { get; }

        private int Validate(int input)
        {
            if (input < 0 || input > 999999999)
            {

                return -1;
            }
            else return input;
        }


        public Input(int input)
        {
            value = Validate(input);

        }

    }
}
