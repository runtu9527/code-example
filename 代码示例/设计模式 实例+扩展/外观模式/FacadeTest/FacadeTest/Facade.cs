using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeTest
{
    class Facade
    {
        SubSystemOne systemOne;
        SubSystemTwo systemTwo;
        SubSystemThree systemThree;
        SubSystemFour systemFour;

        public Facade()
        {
            systemOne = new SubSystemOne();
            systemTwo = new SubSystemTwo();
            systemThree = new SubSystemThree();
            systemFour = new SubSystemFour();
        }
        public void MethodA()
        {
            Console.WriteLine("\n方法组A()************");
            systemOne.MethodOne();
            systemThree.MethodThree();
        }

        public void MethodB()
        {
            Console.WriteLine("\n方法组B()************");
            systemTwo.MethodTwo();
            systemFour.MethodFour();
        }
    }
}
