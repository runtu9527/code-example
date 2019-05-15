using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    /// <summary>
    /// 中介者基类
    /// </summary>
    class Mediator : IMediator
    {
        public object data { get; set; }

        public MediatorPater mediator { get; set; }

        public object buffer_memory { get; set; }//缓存区


        private ObservableCollection<IColleague> colleagues = new ObservableCollection<IColleague>();
        public ObservableCollection<IColleague> Colleagues
        {
            get { return colleagues; }
            set { colleagues = value; }
        }

        public virtual void Registor(IColleague colleague)
        {
            var coll = FindColleague(colleague);
            if (coll == null)
                Colleagues.Add(colleague);
        }
        public virtual void UnRegistor(IColleague colleague)
        {
            var coll = FindColleague(colleague.Mode);
            if (coll != null)
                Colleagues.Remove(colleague);
        }

        public virtual IColleague FindColleague(IColleague colleague)
        {
            int mode = colleague.Mode;
            var coll = Colleagues.ToList<IColleague>().Find(delegate(IColleague cg) { return cg.Mode == mode; });
            return coll;
        }
        public virtual IColleague FindColleague(int mode)
        {
            var coll = Colleagues.ToList<IColleague>().Find(delegate(IColleague cg) { return cg.Mode == mode; });
            return coll;
        }
        /// <summary>
        /// 在继承类中重写
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="msg"></param>
        public virtual void SendMessage(int mode, object msg)
        {
            //重写
        }

        /// <summary>
        /// 模块向指定目标发送数据
        /// </summary>
        /// <param name="targetmode">待接收数据模块的Mode</param>
        /// <param name="mode">发出数据的模块Model</param>
        /// <param name="data"></param>
        public virtual void TargetColleagueReceive(int targetmode, int mode, object data)
        {
            var coll = FindColleague(targetmode);
            if (coll != null)
            {
                ((IColleague)coll).ReceiveMessage(mode, data);
            }
        }

    }

}
