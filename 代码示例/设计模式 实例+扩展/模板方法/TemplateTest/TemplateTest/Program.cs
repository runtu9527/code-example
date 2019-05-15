using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TestPaper A = new StudentA();
            A.Question1();
            A.Question2();

            TestPaper B = new StudentB();
            B.Question1();
            B.Question2();

            Console.Read();
        }
    }
}
