using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateTest
{
    class EveningState:IState
    {
        public void WriteProgram(Work w)
        {
            if (w.Hour < 21)
            {
                Console.WriteLine("当前时间:{0}点 加班哦,累死累活", w.Hour);
            }
            else
            {
                w.SetState(new SleepingState());
                w.WriteProgram();
            }
        }
    }
}
