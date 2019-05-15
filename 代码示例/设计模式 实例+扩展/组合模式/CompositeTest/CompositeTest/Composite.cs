using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeTest
{
    /// <summary>
    /// 定义有枝节点的行为,在此类中实现与子部件有关的操作
    /// </summary>
    class Composite:IComponent
    {
        public string Name { get; set; }
        public int Level { get; set; }
        /// <summary>
        /// 一个子对象集合,用来存储其下属的枝节点和叶节点
        /// </summary>
        public List<IComponent> Children { get; set; }

        public Composite()
        {
            Children = new List<IComponent>();
        }
        public void Add(IComponent component)
        {
            Children.Add(component);
        }

        public void Remove(IComponent component)
        {
            Children.Remove(component);
        }

        public void Display()
        {
            Console.WriteLine("等级:{0}  名称:{1}", Level, Name);
            foreach (var component in Children)
            {
                component.Display();
            }
        }
    }
}
