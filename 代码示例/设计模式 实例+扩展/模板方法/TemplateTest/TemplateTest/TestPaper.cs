using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateTest
{
    /// <summary>
    /// 一个模板方法,定义了算法的骨架,其某些细节放到其子类中去实现
    /// </summary>
    class TestPaper
    {
        public void Question1()
        {
            Console.WriteLine(" 下水道井盖为什么是圆的？ A.为了美观 B.为了节省材料  C.为了防止井盖掉到井里 D.为了搬运方便 ");
            Console.WriteLine("答案:" + Answer1());
        }

        public virtual string Answer1()
        {
            return "";
        }

        public void Question2()
        {
            Console.WriteLine(" 下列情形不可能发生的是：  A.河姆渡原始居民种植水稻，过着定居的生活 B.唐朝的儿童通过《九章算术》学习数学知识 C.东汉商人在商贸活动中已经大规模使用纸币  D.南宋时期，在战场上出现一种新的管状火器");
            Console.WriteLine("答案:" + Answer2());
        }

        public virtual string Answer2()
        {
            return "";
        }
    }
}
