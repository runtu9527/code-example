using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //实例化一个指挥者(餐厅服务员)
            Director director = new Director();
            //实例化两个具体建造者(用户点餐)
            ConcreatBuilder1 builder1 = new ConcreatBuilder1();
            ConcreatBuilder2 builder2 = new ConcreatBuilder2();
            //指挥者去建造第一个产品(做小菜)
            director.Construct(builder1);
            //建造者加入自己私有的建造步骤(加入秘方)
            builder1.BuilderPartC();
            //得到产品(上菜)
            Product product1 = builder1.GetResult();
            product1.Show();

            director.Construct(builder2);
            builder2.BuilderPartC();
            Product product2 = builder2.GetResult();
            product2.Show();

            Console.Read();
        }
    }
}
