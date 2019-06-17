using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactor
{
    public interface IBaseUser
    {
        void Insert(User user);
        User GetUser(int id);
    }
}
