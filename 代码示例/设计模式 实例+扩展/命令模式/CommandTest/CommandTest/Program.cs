using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //命令模式:将一个请求封装为一个对象,从而可用不同的请求对客户进行参数化,对请求排队,或者记录请求日志,以及支持可撤销的操作

            //厨师
            Receiver r = new Receiver();
            //客户提交的菜单
            Command c = new ConcreatCommand(r);
            Command c2 = new ConcreatCommand2(r);
            //服务员
            Invoker i = new Invoker();

            //客户向服务员点餐
            i.SetCommand(c);
            //客户取消订单
            i.RemoveCommand(c);
            i.SetCommand(c2);
            //服务员提交菜单
            i.ExecuteCommand();

            Console.Read();
        }
    }
}
