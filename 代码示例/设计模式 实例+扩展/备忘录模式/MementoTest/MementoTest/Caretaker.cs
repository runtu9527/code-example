using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoTest
{
    /// <summary>
    /// 管理者类 得到或设置备忘录
    /// </summary>
    class Caretaker
    {
        public static List<Memento> Mementos { get; set; }

        static Caretaker()
        {
            Mementos = new List<Memento>();
        }
    }
}
