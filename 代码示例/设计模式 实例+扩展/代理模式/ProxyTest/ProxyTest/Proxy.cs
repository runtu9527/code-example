using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyTest
{
    /// <summary>
    /// 代理者
    /// </summary>
    class Proxy:ISubject
    {
        /// <summary>
        /// 委托对象
        /// </summary>
        public RealSubject Subject { get; set; }
        /// <summary>
        /// 委托方法
        /// </summary>
        public void Request()
        {
            if (Subject == null)
            {
                Console.WriteLine("找不到委托对象");
            }
            Subject.Request();
        }
    }
}
