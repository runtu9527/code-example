using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //实例化一个对象
            ConcreatComponent men = new ConcreatComponent();
            //实例化一个装饰对象A
            DecoratorA decoratorA = new DecoratorA();
            //实例化一个装饰对象B
            DecoratorB decoratorB = new DecoratorB();
            //用A装饰men
            decoratorA.SetComponent(men);
            //用B装饰A
            decoratorB.SetComponent(decoratorA);
            //执行最终装饰完成的操作
            decoratorB.Operation();

            Console.Read();
        }
    }
}
