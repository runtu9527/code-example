using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandTest
{
    /// <summary>
    /// 将一个接受者对象绑定于一个动作,调用接受者相应的操作 (具体的命令类)  (相当于客户的菜单)
    /// </summary>
    class ConcreatCommand:Command
    {
        public ConcreatCommand(Receiver receive)
            : base(receive)
        {
            this.CommName = "大鸡翅";
        }

        public override void Execute()
        {
            receiver.Action();
        }
    }
}
