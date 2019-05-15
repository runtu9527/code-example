using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverTest
{
    /// <summary>
    /// 一个单例模式的类,用来注册和声明通知者
    /// </summary>
    public class Overall
    {
        private static volatile Overall instance = null;
        private static object lockHelper = new object();
        private Overall()
        {
            ObserverList = new List<IObserver>();
        }
        public static Overall Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockHelper)
                    {
                        if (instance == null)
                        {
                            instance = new Overall();
                        }
                    }
                }
                return instance;
            }
        }

        public List<IObserver> ObserverList;

        public IBaseSubjectModel Subject;

        public void InitSubject(IBaseSubjectModel subject)
        {
            Subject = subject;
        }
    }
}
