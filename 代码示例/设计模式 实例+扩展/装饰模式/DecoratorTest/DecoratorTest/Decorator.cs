using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorTest
{
    /// <summary>
    /// 装饰抽象类,从外类来扩展Component类的功能
    /// </summary>
    abstract class Decorator : IComponent
    {
        protected IComponent compontent;
        /// <summary>
        /// 设置要装饰的对象
        /// </summary>
        /// <param name="compt"></param>
        public void SetComponent(IComponent compt)
        {
            this.compontent = compt;
        }
        /// <summary>
        /// 对象操作,每一个对象调用此方法时,都先调用自己所装饰的对象的方法
        /// </summary>
        public virtual void Operation()
        {
            if (this.compontent != null)
            {
                compontent.Operation();
            }
        }
    }
}
