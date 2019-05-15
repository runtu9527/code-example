using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWeight
{
    /// <summary>
    /// 所有具体享元类的接口,可以接受并作用于外部状态
    /// </summary>
    abstract class Flyweight
    {
        public User User;
        public abstract void Operation(int extrins);
    }
}
