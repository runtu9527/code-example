using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace BridgeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //桥接模式,系统可能有多角度分类,每一种分类都有可能变化,
            HandSetBrandA A = new HandSetBrandA();
            A.Soft = new HandSetGame();
            A.Run();

            A.Soft = new HandSetAddressList();
            A.Run();

            HandSetBrandB B = new HandSetBrandB();
            B.Soft = new HandSetGame();
            B.Run();
            
            B.Soft = new HandSetAddressList();
            B.Run();

            Console.Read();
        }
    }
}
