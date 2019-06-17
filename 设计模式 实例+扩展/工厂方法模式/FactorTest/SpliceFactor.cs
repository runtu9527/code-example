using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorTest
{
    /// <summary>
    /// 拼接屏工厂
    /// </summary>
    class SpliceFactor:IFactor
    {

        public Factor CreatFactor()
        {
            return new SpliceScreen();
        }
    }
}
