using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterTest
{
    /// <summary>
    /// 正常接口实现(也就是原配)
    /// </summary>
    class NormalTarget:IBaseTarget
    {
        public void Request()
        {
            Console.WriteLine("接口的正常实现");
        }
    }
}
