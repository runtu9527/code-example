using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoTest
{
    /// <summary>
    /// 备忘录类,需要保存的数据
    /// </summary>
    class Memento
    {
        public int Health { get; set; }
        /// <summary>
        /// 备忘录的唯一索引,可能有多个备忘录
        /// </summary>
        public int Index { get; set; }
        public Memento(int index, object data)
        {
            Index = index;
            Health = (int)data;
        }
    }
}
