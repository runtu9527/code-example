using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactor
{
    public interface IBaseDepartment
    {
        void Insert(Department user);
        Department GetDepartment(int id);
    }
}
