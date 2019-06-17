using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    /// <summary>
    /// 具体中介者 处理一系列工作(可能有多个中介者,一般只有一个) 每一个中介者是唯一的
    /// </summary>
    class MediatorPater:Mediator
    {
        private static readonly object Object = new object();
        private static volatile MediatorPater instance = null;

        public static MediatorPater Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (Object)
                    {
                        if (instance == null)
                        {
                            instance = new MediatorPater();
                        }
                    }
                }
                return instance;
            }
        }

        public override void SendMessage(int mode, object msg)
        {
            //所有的向中介发送的数据都在这儿,中介接收数据以后，对其进行判断和分类,然后决定将该数据传给谁
            MediatorMessage(mode, msg);
        }
    
        private void MediatorMessage(int mode, object data)
        {
            //不同的mode用不同的函数
            int gpmode = mode & 0xFF00000;
            switch (mode)
            {
                case 1: 
                    Person1(mode, data);
                    break;
                case 2:
                    Person2(mode, data);
                    break;
                default: break;
            }
        }
    
        private void Person1(int mode, object data)
        {
            //将数据发往指定的mode对象
            TargetColleagueReceive(2, mode, data);
        }
        private void Person2(int mode, object data)
        {
            //将数据发往指定的mode对象
            TargetColleagueReceive(1, mode, data);
        }
    }
}
