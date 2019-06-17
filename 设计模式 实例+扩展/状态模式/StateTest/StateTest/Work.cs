using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateTest
{
    class Work
    {
        public int Hour { get; set; }

        private IState State { get; set; }

        public Work()
        {
            State = new ForenoonState();
        }

        public void SetState(IState state)
        {
            this.State = state;
        }

        public void WriteProgram()
        {
            State.WriteProgram(this);
        }
    }
}
