using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderTest
{
    /// <summary>
    /// 指挥者,用来指挥建造过程
    /// </summary>
    class Director
    {
        public void Construct(IBuilder builder)
        {
            builder.BuilderPartA();
            builder.BuilderPartB();
        }
    }
}
