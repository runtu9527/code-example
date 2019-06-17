using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWeight
{
    /// <summary>
    /// 一个享元工厂,用来创建并管理flyweight对象,他主要是用来确保合理的共享flyweight,
    /// 当用户请求一个flyweight时,flyweightfactory对象提供一个已创建的实例或者创建一个
    /// </summary>
    class FlyweightFactory
    {
        private List<Flyweight> flyweights = new List<Flyweight>();

        public FlyweightFactory()
        {
        }

        public Flyweight GetFlyweight(User user)
        {
            Flyweight fw = flyweights.Find(p => p.User.Name == user.Name);
            if (fw == null)
            {
                fw = new ConcreatFlyweight(user);
                flyweights.Add(fw);
            }
            return fw;
        }
    }
}
