using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeTest
{
    /// <summary>
    /// 手机品牌接口
    /// </summary>
    interface IHandSetBrand
    {
        IHandSetSoft Soft { get; set; }
        void Run();
       
    }
}
