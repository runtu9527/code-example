using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMehtodTest
{
    //工厂模式基类
    public class Operation
    {
        public double NumberA { get; set; }

        public double NumberB { get; set; }

        public virtual double GetResult()
        {
            double result = 0d;
            return result;
        }
    }
}
