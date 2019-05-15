using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            //中介者模式:用一个中介对象来封装一系列的对象交互,中介者使各对象不需要显式的相互引用,从而使耦合松散,从而可以独立的改变他们之间的交互

            Colleague c1 = new ConcreatColleague1(MediatorPater.Instance);
            Colleague c2 = new ConcreatColleague2(MediatorPater.Instance);

            c1.SendMessage(1, "c1发送的数据");
            c2.SendMessage(2, "c2发送的数据");

            c1.SendToTarget(2, 1, "c1指定向c2发送数据");
            Console.Read();

            //将中介者改为单例模式,始终保持不同类型的中介者只有一个;
            //加入了SendToTarget即向指定的模块发送数据,减缓了中介者的压力,但是不便于中介者集中控制(慎用)
        }
    }
}
