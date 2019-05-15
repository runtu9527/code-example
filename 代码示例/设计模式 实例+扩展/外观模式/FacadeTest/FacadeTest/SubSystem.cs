using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeTest
{
    /// <summary>
    /// 4个子系统
    /// </summary>


    class SubSystemOne
    {
        public void MethodOne()
        {
            Console.WriteLine("子系统方法一");
        }
    }

    class SubSystemTwo
    {
        public void MethodTwo()
        {
            Console.WriteLine("子系统方法二");
        }
    }

    class SubSystemThree
    {
        public void MethodThree()
        {
            Console.WriteLine("子系统方法三");
        }
    }

    class SubSystemFour
    {
        public void MethodFour()
        {
            Console.WriteLine("子系统方法四");
        }
    }
}
