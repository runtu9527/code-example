using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeTest
{
    /// <summary>
    /// 叶节点对象,叶节点没有子节点
    /// </summary>
    class Leaf:IComponent
    {
        public string Name { get; set; }
        public int Level { get; set; }

        public List<IComponent> Children { get; set; }
       
        public void Add(IComponent component)
        {
            Console.WriteLine("Cannot add to leaf");
        }

        public void Remove(IComponent component)
        {
            Console.WriteLine("Cannot remove from a leaf");
        }

        public void Display()
        {
            Console.WriteLine("等级:{0}  名称:{1}", Level, Name);
        }
    }
}
