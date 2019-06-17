using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponsibilityTest
{
    /// <summary>
    /// 定义一个处理请求的接口
    /// </summary>
    abstract class Hander
    {
        protected Hander successor;
        /// <summary>
        /// 设置继任者
        /// </summary>
        /// <param name="successor"></param>
        public void SetSuccessor(Hander successor)
        {
            this.successor = successor;
        }
        /// <summary>
        /// 处理请求的抽象方法
        /// </summary>
        /// <param name="request"></param>
        public abstract void HandleRequest(int request);
    }
}
