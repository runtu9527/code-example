using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorTest
{
    /// <summary>
    /// 工厂类
    /// </summary>
    public class Factor
    {
        public void Sweep()
        {
            Console.WriteLine("扫地机器人");
        }
        public void Wash()
        {
            Console.WriteLine("洗衣机器人");
        }
        public void DoFood()
        {
            Console.WriteLine("做饭机器人");
        }
    }
}
