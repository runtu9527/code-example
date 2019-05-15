using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;

namespace AbstractFactor
{
    class DBType
    {
        private static readonly string _dbType = ConfigurationManager.AppSettings["DB"].ToString();
        //private static readonly string _dbType = "SqlServer";
        private static readonly string _assblyName = "AbstractFactor";

        private Assembly assembly;
        public DBType()
        {
            assembly = System.Reflection.Assembly.Load(_assblyName);
        }

        public object CreatDBInfo(string dbName)
        {
            string className = _assblyName + "." + _dbType + dbName;
            return (object)assembly.CreateInstance(className);
        }

    }
}
