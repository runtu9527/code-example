using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorTest
{
    //恋爱 具体访问者
    class Amativeness:Action
    {
        public override void GetManConclusion(Man man)
        {
            Console.WriteLine("{0}{1}时,机智如我", man.GetType().Name, this.GetType().Name);
        }

        public override void GetWomanConclusion(Woman woman)
        {
            Console.WriteLine("{0}{1}时,智商欠费", woman.GetType().Name, this.GetType().Name);
        }
    }
}
