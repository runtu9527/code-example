using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> Iterator = new List<int>();
            Iterator.Add(2);
            Iterator.Add(5);
            Iterator.Add(67);
            Iterator.Add(13);
            Iterator.Add(345);
            Iterator.Add(796);
            Iterator.Add(72);

            //foreach其实就是一个迭代器模式  顺序访问一个聚合对象的各个元素,而不暴露该对象的内部表示
            foreach (var temp in Iterator)
            {
                Console.WriteLine(temp);
            }

            Console.Read();
        }
    }
}
