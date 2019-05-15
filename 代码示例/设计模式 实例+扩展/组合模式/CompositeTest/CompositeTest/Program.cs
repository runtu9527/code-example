using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Composite root = new Composite();
            root.Level = 0;
            root.Name = "管理员";
            AddChildren(root, 1, "name1");
            AddChildren(root, 1, "name2");
            AddChildren(root, 1, "name3");
            AddChildren(root, 1, "name4");
            AddChildren(root.Children[0], 2, "name5");
            AddChildren(root.Children[1], 2, "name6");
            AddChildren(root.Children[2], 2, "name7");
            AddChildren(root.Children[3], 2, "name8");
            root.Display();

            Console.Read();

        }

        private static void AddChildren(IComponent p, int level, string name)
        {
            Composite leaf = new Composite();
            leaf.Level = level;
            leaf.Name = name;
            p.Add(leaf);
        }
    }
}
