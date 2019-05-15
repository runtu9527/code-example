using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeTest
{
    class HandSetBrandB:IHandSetBrand
    {
        public IHandSetSoft Soft{ get; set; }

        public void Run()
        {
            Console.WriteLine("运行B品牌");
            Soft.Run();
        }
    }
}
