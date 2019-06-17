using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWeight
{
    /// <summary>
    /// 不需要共享的flyweight子类,
    /// </summary>
    class UnshardConcreatFlyweight:Flyweight
    {
        public UnshardConcreatFlyweight(User user)
        {
            this.User = user;
        }
        public override void Operation(int extrins)
        {
            Console.WriteLine("不共享的具体的Flyweight:" + extrins + "具体的外部用户" + User.Name);
        }
    }
}
