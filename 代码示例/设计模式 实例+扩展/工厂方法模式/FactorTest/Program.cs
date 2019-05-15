using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //工厂方法模式  每一个类对应一个工厂,相较于简单工厂,去除了switch和case 保留了简单工厂的优点,克服了简单工厂违背开放-封闭原则的缺点
            //由于每加一个产品,就需要加一个产品工厂的类,增加了额外的开发量(利用反射可以避免分支判断问题)


            //选择一个工厂
            IFactor factor = new LockFactor();
            //IFactor factor = new SpliceFactor();
            //创建工厂实例
            Factor product = factor.CreatFactor();

            //工厂类方法
            product.DoFood();
            product.Sweep();
            product.Wash();

            Console.Read();
            
        }
    }
}
