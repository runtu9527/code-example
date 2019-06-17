using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeTest
{
    class Program
    {
        static void Main(string[] args)
        {

            //外观模式,也是最常用的模式,一个类对象中调用其他类对象

            Facade facade = new Facade();
            facade.MethodA();
            facade.MethodB();

            Console.Read();

        }
    }
}
