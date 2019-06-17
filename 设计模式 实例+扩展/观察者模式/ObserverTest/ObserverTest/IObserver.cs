using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverTest
{
    /// <summary>
    /// 抽象观察者,提供一系列事件响应,和注册注销
    /// </summary>
    public interface IObserver
    {
        int Mode { get; set; }

        IBaseSubjectModel subject { get; set; }

        /// <summary>
        /// 通讯响应
        /// </summary>
        /// <param name="data"></param>
        void Observer_Comm_Respone(int mode, object data);
        /// <summary>
        /// 存储响应
        /// </summary>
        /// <param name="data"></param>
        void Observer_Save_Respone(int mode, object data);
        /// <summary>
        /// 日志响应
        /// </summary>
        /// <param name="data"></param>
        void Observer_Log_Respone(int mode, object data);

        #region[数据操作]

        IObserver GetTarget(int targetMode);
        /// <summary>
        /// 接收到其它观察者传符合的数据
        /// </summary>
        /// <param name="sourceMode">其它观察者</param>
        /// <param name="data"></param>
        void ReceiveCommand(int sourceMode, object data);
        /// <summary>
        /// 向目标观察者发送数据
        /// </summary>
        /// <param name="targetMode">目标观察者</param>
        /// <param name="ownMode">传答者自身</param>
        /// <param name="data"></param>
        void SendToTarget(int targetMode, int ownMode, object data);

        #endregion

        #region[注册]

        /// <summary>
        ///  注册观察者
        /// </summary>
        /// <param name="target"></param>
        void Register(IObserver target);

        /// <summary>
        /// 注销观察者
        /// </summary>
        /// <param name="target"></param>
        void UnRegister(IObserver target);

        #endregion
    }
}
