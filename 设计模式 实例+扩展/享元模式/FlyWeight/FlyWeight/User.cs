using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWeight
{
    /// <summary>
    /// 享元类的外部状态类
    /// </summary>
    class User
    {
        public string Name { get; set; }
        public User(string name)
        {
            this.Name = name;
        }
    }
}
