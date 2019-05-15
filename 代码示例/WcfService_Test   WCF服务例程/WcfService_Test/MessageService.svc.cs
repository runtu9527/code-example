using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfService_Test
{
    /// <summary>
    /// 双工通信
    /// </summary>
     [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class MessageService : IMessageService
    {
        
        
        public void SendToAll(string name, string msg)
        {
            ICallBack callback = OperationContext.Current.GetCallbackChannel<ICallBack>();
            //Task.Factory.StartNew(new Action(() =>
            //{
                
            //}));
            callback.Show();
        }

        public int Regist()
        {
            //callback = OperationContext.Current.GetCallbackChannel<ICallBack>();
            return 1;
        }
    }
}
