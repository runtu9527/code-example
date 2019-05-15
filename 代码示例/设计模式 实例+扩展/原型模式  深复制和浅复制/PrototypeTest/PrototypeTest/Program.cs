using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Resume li = new Resume();
            li.SetName("xiaoming");
            li.SetWorkExperience("qunxin", "shenzhen");

            //浅复制
            //Resume bao = (Resume)li.Clone();
            //bao.SetWorkExperience("chuangwei", "shenzhen");

            //深复制
            Resume bao = (Resume)li.Copy();
            bao.SetWorkExperience("chuangwei", "shenzhen");

            li.Display();
            bao.Display();

            Console.Read();
        }
    }
}
