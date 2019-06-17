using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandTest
{
    /// <summary>
    /// 要求该命令执行这个请求 (服务员)
    /// </summary>
    class Invoker
    {
        private List<Command> orders = new List<Command>();
        public void SetCommand(Command comm)
        {
            orders.Add(comm);
            Console.WriteLine("增加订单:" + comm.CommName + "  时间:" + System.DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
        }

        public void RemoveCommand(Command comm)
        {
            orders.Remove(comm);
            Console.WriteLine("取消订单:" + comm.CommName + "  时间:" + System.DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
        }

        public void ExecuteCommand()
        {
            foreach (var comm in orders)
            {
                comm.Execute();
            }
        }
    }
}
