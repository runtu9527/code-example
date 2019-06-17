using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactor
{
    public class AccessUser:IBaseUser
    {
        public void Insert(User user)
        {
            Console.WriteLine("在Access 中给User表增加一条记录");
        }

        public User GetUser(int id)
        {
            Console.WriteLine("在Access 中根据ID得到User表一条记录");
            return null;
        }
    }
}
