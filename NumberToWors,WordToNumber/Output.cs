using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWors_WordToNumber
{
    public class Output
    {

        private dynamic result { get; }
        private int id { get; }
        public Output(dynamic Salir)
        {
            result = Salir;
            id = generateId();
        }

        public dynamic GetResult()
        {
            return result;
        }

        static int generateId()
        {
            int counter = 0;
            return ++counter;
        }



    }
}
