using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService_Test
{
    //和单向操作相比，我们会发现服务契约上多了一行代码：[ServiceContract(CallbackContract = typeof(ICallBack))]
    [ServiceContract(CallbackContract = typeof(ICallBack))]
    public interface IMessageService
    {
        [OperationContract]
        int Regist();
        [OperationContract(IsOneWay=true)]
        void SendToAll(string name, string msg);
    }

    public interface ICallBack
    {
        [OperationContract(IsOneWay = true)]
        void Show();
    }
}
