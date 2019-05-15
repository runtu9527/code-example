using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponsibilityTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //职责链模式:使多个对象都有机会处理请求,从而避免请求的发送者和接受者之间的耦合关系.
                       //将这个对象连城一条链,并沿着这条链传递该请求,直到有一个对象处理它为止
            Hander h1 = new ConcreatHander1();
            Hander h2 = new ConcreatHander2();
            Hander h3 = new ConcreatHander3();

            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);

            int[] request = { 2, 5, 14, 22, 18, 3, 27, 20 };

            foreach (var temp in request)
            {
                h1.HandleRequest(temp);
            }

            Console.Read();

            /*
           职责链模式与状态模式的最大的不同是设置自己的下一级的问题上，
           状态模式是在类的设计阶段就定好的，不能在客户端改变，
           而职责链的下一级是在客户端自己来确定的。这样各有什么优缺点呢？
           在类的设计阶段设定（状态模式）的好处是不用客户来确定下一状态，
           也就减少了客户设置错误的问题，客户也不用知道状态的具体结构，
           同时存在灵活性差，耦合度高的问题，从上面的例子可以看到，
           因为作用域的问题，ConStateC一定要写在ConStateB之前，ConStateB一定要写在ConStateA之前，
           顺序不能乱。而在客户端设定（职责链模式）要求客户对各个类的职责要有所了解，
           并能正确设置好职责链，并加大设置出错的风险。但是它也比较灵活，也不存在刚才在状态模式中说的耦合和作用域问题。
           */
        }
    }
}
