using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoTest
{
    /// <summary>
    /// 发起人 类,即需要保存某一部分并恢复的类
    /// </summary>
    class Originator
    {
        public int Health { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 当前创建的备忘录标识列表
        /// </summary>
        public List<int> MementoUids = new List<int>();

        public Originator()
        {
            
        }

        int i = 0;
        /// <summary>
        /// 创建备忘录,将当前需要保存的信息导入,并实例化一个对象
        /// </summary>
        /// <returns></returns>
        public Memento CreatMemento()
        {
            MementoUids.Add(i);
            return (new Memento(i++, Health));
        }
        /// <summary>
        /// 恢复备忘录
        /// </summary>
        /// <param name="memento"></param>
        public void SetMemento(Memento memento)
        {
            this.Health = memento.Health;
        }

        public void Show()
        {
            Console.WriteLine("Health:{0}", Health);
        }
    }
}
