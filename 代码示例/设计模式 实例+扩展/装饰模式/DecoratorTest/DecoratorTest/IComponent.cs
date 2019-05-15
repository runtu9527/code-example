using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorTest
{
    /// <summary>
    /// 定义一个对象接口,可以给这些对象动态的添加职责
    /// </summary>
    public interface IComponent
    {
        void Operation();
    }
}
