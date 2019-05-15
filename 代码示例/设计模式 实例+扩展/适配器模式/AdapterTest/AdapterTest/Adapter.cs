using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterTest
{
    /// <summary>
    /// 自定义一个适配器,用来将特殊类或者接口转换为用户需要调用的接口
    /// </summary>
    class Adapter:IBaseTarget
    {
        private AdapteeTarget adaptee = new AdapteeTarget();
        public void Request()
        {
            adaptee.SpecificRequest();
        }
    }
}
