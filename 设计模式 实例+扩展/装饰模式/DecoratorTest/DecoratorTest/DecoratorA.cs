using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorTest
{
    /// <summary>
    /// 具体的装饰对象,给component添加职责
    /// </summary>
    class DecoratorA:Decorator
    {
        private string AddeState;  //本类独有的功能

        public override void Operation()
        {
            base.Operation();
            AddeState = "New State";
            Console.WriteLine("具体的装饰对象A的操作{0}", AddeState);
        }
    }
}
