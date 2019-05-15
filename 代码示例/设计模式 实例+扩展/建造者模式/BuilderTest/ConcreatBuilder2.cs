using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderTest
{
    /// <summary>
    /// 具体建造者2,建造具体的部件
    /// </summary>
    class ConcreatBuilder2:IBuilder
    {
        private Product product = new Product();
        public void BuilderPartA()
        {
            product.Add("部件X");
        }

        public void BuilderPartB()
        {
            product.Add("部件Y");
        }

        public void BuilderPartC()
        {
            product.Add("部件Z");
        }

        public Product GetResult()
        {
            return product;
        }
    }
}
