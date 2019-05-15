using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
namespace Mediator
{
    /// <summary>
    /// 具体同事基类
    /// </summary>
    class Colleague : PropertyChangedBase, IColleague
    {
        public Colleague(IMediator mediator)
        {
            // TODO: Complete member initialization
            this.Mediator = mediator;
        }
        //public IMediator mediator { set; get; }

        public IMediator mediator { set; get; }
        public IMediator Mediator
        {
            get { return mediator; }
            set
            {
                mediator = value;
                NotifyOfPropertyChange(() => Mediator);
            }
        }

        public int Mode { get; set; }

        /// <summary>
        /// 向中介发送数据
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="data"></param>
        public void SendMessage(int mode, object data)
        {
            Mediator.SendMessage(mode, data);
        }
        /// <summary>
        /// 向指定模块发送数据
        /// </summary>
        /// <param name="targetMode"></param>
        /// <param name="mode"></param>
        /// <param name="data"></param>
        public void SendToTarget(int targetMode, int mode, object data)
        {
            Mediator.TargetColleagueReceive(targetMode, mode, data);
        }
        /// <summary>
        /// 接受来自中介的消息
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="data"></param>
        public virtual void ReceiveMessage(int mode, object data) { }
    }
}
