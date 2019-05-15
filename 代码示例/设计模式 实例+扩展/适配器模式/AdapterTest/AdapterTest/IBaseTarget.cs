using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterTest
{
    /// <summary>
    /// 基础接口,也就是客户要用到的接口
    /// </summary>
    interface IBaseTarget
    {
        void Request();
    }
}
