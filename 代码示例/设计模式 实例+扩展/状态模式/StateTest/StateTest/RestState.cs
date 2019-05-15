using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateTest
{
    class RestState:IState
    {
        public void WriteProgram(Work w)
        {
            Console.WriteLine("当前时间:{0}点 回家喽", w.Hour);
        }
    }
}
