using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyTest
{
    /// <summary>
    /// 代理者和委托者共用的接口,提供代理的方法
    /// </summary>
    public interface ISubject
    {
        void Request();
    }
}
