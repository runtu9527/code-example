using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    /// <summary>
    /// 具体同事类2
    /// </summary>
    class ConcreatColleague2:Colleague
    {
        public ConcreatColleague2(Mediator mediator)
            : base(mediator)
        {
            Mode = 2;
            mediator.Registor(this);

            
        }

        public override void ReceiveMessage(int mode, object data)
        {
            Console.WriteLine("{0} 接收到 {1} 的消息:{2}", this.Mode, mode, data.ToString());
        }
    }
}
