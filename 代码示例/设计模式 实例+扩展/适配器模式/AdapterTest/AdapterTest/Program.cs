using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //适配器模式,客户只访问正常接口,或者适配器

            IBaseTarget target = new NormalTarget();
            target.Request();

            target = new Adapter();
            target.Request();

            Console.Read();
        }
    }
}
