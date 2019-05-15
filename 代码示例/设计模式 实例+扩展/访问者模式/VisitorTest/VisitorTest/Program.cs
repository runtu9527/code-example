using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //访问者模式:表示一个作用于某对象结构中的各元素的操作,它使你可以在不改变各元素的类的前提下定义作用于这些元素的新操作\

            //适用于数据机构相对稳定的系统
            ObjectStructure os = new ObjectStructure();
            os.Attach(new Man());
            os.Attach(new Woman());

            Success sc = new Success();
            os.Display(sc);

            Amativeness am = new Amativeness();
            os.Display(am);

            Console.Read();
        }
    }
}
