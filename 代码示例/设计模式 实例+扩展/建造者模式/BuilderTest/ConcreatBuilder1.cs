using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderTest
{
    /// <summary>
    /// 具体建造者1,建造具体的部件
    /// </summary>
    class ConcreatBuilder1:IBuilder
    {
        private Product product = new Product();
        public void BuilderPartA()
        {
            product.Add("部件A");
        }

        public void BuilderPartB()
        {
            product.Add("部件B");
        }

        public void BuilderPartC()
        {
            product.Add("部件C");
        }

        public Product GetResult()
        {
            return product;
        }
    }
}
