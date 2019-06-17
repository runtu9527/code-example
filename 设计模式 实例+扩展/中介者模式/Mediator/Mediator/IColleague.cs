using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    /// <summary>
    /// 抽象同事接口
    /// </summary>
    interface IColleague
    {
        IMediator mediator { get; set; }
        int Mode { get; set; }
        /// <summary>
        /// 向中介发送数据
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="data"></param>
        void SendMessage(int mode, object data);
        /// <summary>
        /// 向指定模块发送数据
        /// </summary>
        /// <param name="targetMode"></param>
        /// <param name="mode"></param>
        /// <param name="data"></param>
        void SendToTarget(int targetMode, int mode, object data);
        /// <summary>
        /// 接受来自中介者的消息
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="data"></param>
        void ReceiveMessage(int mode, object data);
    }
}
