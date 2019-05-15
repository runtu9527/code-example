using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorTest
{
    /// <summary>
    /// 抽象工厂
    /// </summary>
    interface IFactor
    {
        Factor CreatFactor(); 
    }
}
