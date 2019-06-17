using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandTest
{
    class ConcreatCommand2:Command
    {
         public ConcreatCommand2(Receiver receive)
            : base(receive)
        {
            this.CommName = "羊肉串";
        }

        public override void Execute()
        {
            receiver.Action();
        }
    }
}
