using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactor
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            Department department = new Department();

            DBType dbType = new DBType();

            IBaseUser db = (IBaseUser)dbType.CreatDBInfo("User");
            IBaseDepartment depart = (IBaseDepartment)dbType.CreatDBInfo("Department");

            db.Insert(user);
            db.GetUser(1);
            depart.Insert(department);
            depart.GetDepartment(1);

            Console.Read();

        }
    }
}
