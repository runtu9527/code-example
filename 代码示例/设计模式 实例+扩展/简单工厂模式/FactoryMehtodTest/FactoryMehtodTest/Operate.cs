using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMehtodTest
{
    public class Operate
    {
        //普通实现,不利于扩充,且耦合性较高
        public static double GetResult(double numberA, double numberB, string operate)
        {
            double result = 0d;
            switch (operate)
            {
                case "+": result = numberA + numberB; break;
                case "-": result = numberA - numberB; break;
                case "*": result = numberA * numberB; break;
                case "/": result = numberA / numberB; break;
                default: break;
            }
            return result;
        }
    }
}
