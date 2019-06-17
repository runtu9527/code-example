using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMehtodTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("请输入数字A: ");
            string A = Console.ReadLine();
            Console.Write("请输入符号B: ");
            string B = Console.ReadLine();
            Console.Write("请输入数字C: ");
            string C = Console.ReadLine();

            Operation ope = OperationFactory.CreatOperation(B);
            ope.NumberA = Convert.ToDouble(A);
            ope.NumberB = Convert.ToDouble(C);
            double D = ope.GetResult();

            Console.WriteLine("结果是{0}", D);
            Console.ReadLine();
        }
    }
}
