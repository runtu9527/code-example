using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandTest
{
    /// <summary>
    /// 用来声明执行操作的接口  (抽象命令类)
    /// </summary>
    abstract class Command
    {
        protected Receiver receiver;

        public string CommName;
        public Command(Receiver receive)
        {
            this.receiver = receive;
        }

        abstract public void Execute();
    }
}
