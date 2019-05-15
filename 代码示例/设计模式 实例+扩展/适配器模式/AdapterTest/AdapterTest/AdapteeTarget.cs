using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterTest
{
    /// <summary>
    /// 需要适配的类或者接口,此类比较特殊,不能直接实现,因此需要一个适配器作为转换
    /// </summary>
    class AdapteeTarget
    {
        public void SpecificRequest()
        {
            Console.WriteLine("一个特殊的实现");
        }
    }
}
