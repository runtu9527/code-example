using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //初始化一个委托者
            RealSubject real = new RealSubject();
            //初始化一个代理者
            Proxy proxy = new Proxy();
            //委托者和代理者建立关系
            proxy.Subject = real;
            //代理者去完成某事
            proxy.Request();

            Console.Read();
        }
    }
}
