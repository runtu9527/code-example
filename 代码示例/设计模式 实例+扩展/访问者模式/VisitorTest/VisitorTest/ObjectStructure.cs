using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorTest
{
    /// <summary>
    /// 对象结构类  用来管理对象(男人和女人)
    /// </summary>
    class ObjectStructure
    {
        private List<Person> elements = new List<Person>();

        //增加
        public void Attach(Person element)
        {
            elements.Add(element);
        }
        //移除
        public void Detach(Person element)
        {
            elements.Remove(element);
        }
        //查看显示
        public void Display(Action visitor)
        {
            foreach (var persion in elements)
            {
                persion.Accept(visitor);
            }
        }
    }
}
