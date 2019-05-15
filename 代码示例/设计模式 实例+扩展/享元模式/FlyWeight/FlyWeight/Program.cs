using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWeight
{
    class Program
    {
        static void Main(string[] args)
        {
            //享元模式:运用共享技术有效的支持大量细粒度的对象

            //初始化外部状态类,初始化两个用户
            User user1 = new User("小明");
            User user2 = new User("小红");

            //初始化一个享元工厂
            FlyweightFactory f = new FlyweightFactory();
            Flyweight fw1 = f.GetFlyweight(user1);
            fw1.Operation(1);
            Flyweight fw2 = f.GetFlyweight(user2);
            fw2.Operation(2);

            Flyweight fw3 = f.GetFlyweight(user1);
            fw3.Operation(3);

            Console.Read();
        }
    }
}
