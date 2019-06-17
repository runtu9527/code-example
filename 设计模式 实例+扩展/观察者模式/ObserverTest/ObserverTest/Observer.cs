using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverTest
{
    /// <summary>
    /// 观察者基类,,(注意:提供了一个单例模式的通知者)
    /// </summary>
    public class Observer : IObserver
    {
        public int Mode { get; set; }
        public IBaseSubjectModel subject { get; set; }

        public Observer()
        {
            subject = Overall.Instance.Subject;
        }
        /// <summary>
        /// 通讯响应
        /// </summary>
        /// <param name="data"></param>
        public virtual void Observer_Comm_Respone(int mode, object data) { }
        /// <summary>
        /// 存储响应
        /// </summary>
        /// <param name="data"></param>
        public virtual void Observer_Save_Respone(int mode, object data) { }
        /// <summary>
        /// 日志响应
        /// </summary>
        /// <param name="data"></param>
        public virtual void Observer_Log_Respone(int mode, object data) { }

        #region[数据操作]

        public IObserver GetTarget(int targetMode)
        {
            IObserver result = mediator.OverAll.ObserverList.Find(delegate(IObserver ob) { return ob.Mode == targetMode; });

            return result;
        }
        /// <summary>
        /// 接收到其它观察者传符合的数据
        /// </summary>
        /// <param name="sourceMode">其它观察者</param>
        /// <param name="data"></param>
        public virtual void ReceiveCommand(int sourceMode, object data)
        {

        }
        /// <summary>
        /// 向目标观察者发送数据
        /// </summary>
        /// <param name="targetMode">目标观察者</param>
        /// <param name="ownMode">传答者自身</param>
        /// <param name="data"></param>
        public void SendToTarget(int targetMode, int ownMode, object data)
        {
            IObserver result = GetTarget(targetMode);
            if (result != null)
            {
                result.ReceiveCommand(ownMode, data);
            }
        }
        #endregion

        #region[注册]

        /// <summary>
        ///  注册观察者
        /// </summary>
        /// <param name="target"></param>
        public void Register(IObserver target)
        {
            IObserver result = mediator.OverAll.ObserverList.Find(delegate(IObserver ob) { return ob.Mode == target.Mode; });

            if (result != null)
            {
                result.subject.ObserverEvent -= new SubjectEventHandler(result.Observer_Comm_Respone);
                mediator.OverAll.ObserverList.Remove(result);
            }
            if (target.subject != null)
            {
                target.subject.ObserverEvent += new SubjectEventHandler(target.Observer_Comm_Respone);
                
                mediator.OverAll.ObserverList.Add(target);
            }

        }

        /// <summary>
        /// 注销观察者
        /// </summary>
        /// <param name="target"></param>
        public void UnRegister(IObserver target)
        {
            IObserver result = mediator.OverAll.ObserverList.Find(delegate(IObserver ob) { return ob == target; });
            if (result != null)
            {
                result.subject.ObserverEvent -= new SubjectEventHandler(Observer_Comm_Respone);
                mediator.OverAll.ObserverList.Remove(target);
            }
        }

        private Mediator mediator = new Mediator();

        #endregion


    }
}
