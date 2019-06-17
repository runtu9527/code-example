using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorTest
{
    /// <summary>
    /// 一个具体的对象,可以给这些对象添加一些职责
    /// </summary>
    class ConcreatComponent:IComponent
    {
        public void Operation()
        {
            Console.WriteLine("具体对象的操作");
        }
    }
}
