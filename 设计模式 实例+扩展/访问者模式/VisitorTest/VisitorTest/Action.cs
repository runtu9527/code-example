using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorTest
{
    /// <summary>
    /// 状态的抽象类 即访问者类 (可能有多种不同的状态)
    /// </summary>
    abstract class Action
    {
        //得到男人结论或者反应
        public abstract void GetManConclusion(Man man);
        //得到女人结论或者反应
        public abstract void GetWomanConclusion(Woman woman);
    }
}
