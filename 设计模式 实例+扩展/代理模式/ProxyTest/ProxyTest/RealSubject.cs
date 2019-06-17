using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyTest
{
    /// <summary>
    /// 委托者
    /// </summary>
    public class RealSubject:ISubject
    {

        public void Request()
        {
            Console.WriteLine("请求做事");
        }
    }
}
