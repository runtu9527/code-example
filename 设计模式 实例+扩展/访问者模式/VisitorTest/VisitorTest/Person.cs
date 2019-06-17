using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorTest
{
    /// <summary>
    /// 人的抽象类 即对象类,此结构是稳定的(只有男人和女人)
    /// </summary>
    abstract class Person
    {
        /// <summary>
        /// 接受某一种状态(即访问者)
        /// </summary>
        /// <param name="visitor"></param>
        public abstract void Accept(Action visitor);
    }
}
