using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpreterTest
{
    /// <summary>
    /// 解释器
    /// </summary>
    abstract class Expression
    {
        /// <summary>
        /// 解释器
        /// </summary>
        /// <param name="context"></param>
        public void Interpret(PlayContext context)
        {
            if (context.PlayTest.Length == 0)
                return;
            else
            {
                string playKey = context.PlayTest.Substring(0, 1);
                context.PlayTest = context.PlayTest.Substring(2);
                double playValue = Convert.ToDouble(context.PlayTest.Substring(0, context.PlayTest.IndexOf(" ")));
                context.PlayTest = context.PlayTest.Substring(context.PlayTest.IndexOf(" ") + 1);
                Excute(playKey, playValue);
            }
        }
        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public abstract void Excute(string key, double value);
    }
}
