using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWeight
{
    /// <summary>
    /// 具体的享元类,并为内部状态增加存储空间
    /// </summary>
    class ConcreatFlyweight:Flyweight
    {
        public ConcreatFlyweight(User user)
        {
            this.User = user;
        }
        public override void Operation(int extrins)
        {
            Console.WriteLine("具体的Flyweight:" + extrins + "具体的外部用户" + User.Name);
        }
    }
}
