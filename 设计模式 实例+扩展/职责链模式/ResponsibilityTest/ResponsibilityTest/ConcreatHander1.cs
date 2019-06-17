using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponsibilityTest
{
    /// <summary>
    /// 具体处理者,处理他所负责的请求,可访问他的后继者,
    /// 如果可处理该请求,就处理之,否则就将该请求转发给他的后继者
    /// </summary>
    class ConcreatHander1:Hander
    {
        public override void HandleRequest(int request)
        {
            if (request >= 0 && request < 10)
            {
                Console.WriteLine("{0} 处理请求 {1}", this.GetType().Name, request);
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }
}
