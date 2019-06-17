using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeTest
{
    /// <summary>
    /// 组合中的对象声明接口,实现所有类共有接口的默认行为
    /// </summary>
    interface IComponent
    {
        string Name { get; set; }
        int Level { get; set; }
        List<IComponent> Children { get; set; }
        void Add(IComponent component);
        void Remove(IComponent component);
        void Display();
    }
}
