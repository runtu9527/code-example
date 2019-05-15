using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpreterTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //解释器模式:给定一个语言,定义它的文法的一种表示,并定义一个解释器,这个解释器使用该表示来解释语言中的句子

            PlayContext context = new PlayContext();

            //音乐-上海滩
            Console.WriteLine("上海滩: ");
            context.PlayTest = "T 800 O 2 E 0.5 G 0.5 A 3 E 0.5 G 0.5 D 3 E 0.5 G 0.5 A 0.5 O 3 C 1 O 2 A 0.5 G 1 C 0.5 E 0.5 D 3 ";
            Expression exp = null;
            try
            {
                while (context.PlayTest.Length > 0)
                {
                    string str = context.PlayTest.Substring(0, 1);
                    switch (str)
                    {
                        case "O": exp = new Scale(); break;
                        case "T": exp = new Speed(); break;
                        case "C":
                        case "D":
                        case "E":
                        case "F":
                        case "G":
                        case "A":
                        case "B":
                        case "P": exp = new Note(); break;
                        default: break;
                    }
                    if (exp != null)
                    {
                        exp.Interpret(context);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
