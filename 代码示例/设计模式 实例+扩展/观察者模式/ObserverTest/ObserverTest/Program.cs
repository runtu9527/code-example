using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverTest
{
    class Program
    {
        //实例化一个通知者
        public static Overall OverAll = Overall.Instance;
        public static SubjectObserver mpater = new SubjectObserver();
       
        static void Main(string[] args)
        {
            //初始化通知者
            mpater.Name = "Subject";
            OverAll.InitSubject(mpater);
           
            //实例化两个观察者
            ModeA modea = new ModeA();
            ModeB modeb = new ModeB();

            //向所有观察者推送消息
            mpater.Notify(3, "开始干活");

            //向目标观察者发送数据
            modea.SendToTarget(2, 1, "偷个懒");

            Console.Read();
        }
    }

    public class ModeA:Observer
    {
        public ModeA()
        {
            Mode = 1;
            Register(this);
        }

        public override void Observer_Comm_Respone(int mode, object data)
        {
            Console.WriteLine("{0},{1}", mode, data.ToString());
           
        }

        public override void ReceiveCommand(int sourceMode, object data)
        {
            
        }
    }

    public class ModeB : Observer
    {
        public ModeB()
        {
            Mode = 2;
            Register(this);
        }

        public override void Observer_Comm_Respone(int mode, object data)
        {
            Console.WriteLine("{0},{1}", mode, data.ToString());
        }

        public override void ReceiveCommand(int sourceMode, object data)
        {
            Console.WriteLine("{0},{1}", sourceMode, data.ToString());
        }
    }
}
