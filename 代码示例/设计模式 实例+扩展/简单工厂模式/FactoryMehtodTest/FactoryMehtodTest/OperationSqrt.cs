using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryMehtodTest
{
    public class OperationSqrt : Operation
    {
        public override double GetResult()
        {
            return Math.Pow(NumberA, NumberB);
        }
    }
}
