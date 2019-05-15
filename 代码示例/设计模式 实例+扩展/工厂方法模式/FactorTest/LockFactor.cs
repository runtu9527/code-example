using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorTest
{
    /// <summary>
    /// 智能锁工厂
    /// </summary>
    class LockFactor:IFactor
    {
        public Factor CreatFactor()
        {
            return new SmartLock();
        }
    }
}
