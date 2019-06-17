using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonTest
{
    class Singleton
    {
        private static readonly object SingleObject = new object();
        private static volatile Singleton instance = null;

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (SingleObject)
                    {
                        if (instance == null)
                        {
                            instance = new Singleton();
                        }
                    }
                }
                return instance;
            }
        }

        public void Show()
        {
            Console.WriteLine("单例模式");
        }
    }
}
