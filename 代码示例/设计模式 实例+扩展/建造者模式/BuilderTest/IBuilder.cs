using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderTest
{
    /// <summary>
    /// 抽象建造者接口,确定产品必须至少由PartA和PartB两部分组成,并声明一个产品建造后的结果的方法
    /// </summary>
    interface IBuilder
    {
        void BuilderPartA();
        void BuilderPartB();
        Product GetResult();
    }
}
