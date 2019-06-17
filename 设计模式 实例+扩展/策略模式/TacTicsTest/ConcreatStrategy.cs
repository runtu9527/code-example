using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacTicsTest
{
    /// <summary>
    /// 算法选择器
    /// </summary>
    public class ConcreatStrategy
    {
        private Strategy strategy;
        public ConcreatStrategy(object type)
        {
            switch (type.ToString())
            {
                case "A": this.strategy = new ConcreatStrategyA(); break;
                case "B": this.strategy = new ConcreatStrategyB(); break;
                case "C": this.strategy = new ConcreatStrategyC(); break;
            }
        }

        public void GetStrategyAlgorithm()
        {
            strategy.AlgorithmRealize();
        }
    }
}
