using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateTest
{
    class SleepingState:IState
    {
        public void WriteProgram(Work w)
        {
            if (w.Hour < 22)
            {
                Console.WriteLine("当前时间:{0}点 快睡着了", w.Hour);
            }
            else
            {
                w.SetState(new RestState());
                w.WriteProgram();
            }
        }
    }
}
