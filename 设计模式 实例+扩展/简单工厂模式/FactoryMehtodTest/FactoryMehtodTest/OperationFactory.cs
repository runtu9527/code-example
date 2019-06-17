using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMehtodTest
{
    public class OperationFactory
    {
        public static Operation CreatOperation(string operate)
        {
            Operation ope = null;
            switch (operate)
            {
                case "+": ope = new OperationAdd(); break;
                case "-": ope = new OperationSub(); break;
                case "*": ope = new OperationMul(); break;
                case "/": ope = new OperationDiv(); break;
                case "^": ope = new OperationSqrt(); break;
                default: break;
            }
            return ope;
        }
    }
}
