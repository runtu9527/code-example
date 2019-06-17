using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //实例化一个基本类
            Originator ori = new Originator();
            ori.Health = 100;
            ori.Show();
            //创建备忘录,加入备忘列表
            Caretaker.Mementos.Add(ori.CreatMemento());

            ori.Health = 80;
            Caretaker.Mementos.Add(ori.CreatMemento());

            ori.Health = 50;
            Caretaker.Mementos.Add(ori.CreatMemento());

            //恢复到之前保存的状态
            ori.SetMemento(Caretaker.Mementos[0]);
            ori.Show();
            ori.SetMemento(Caretaker.Mementos[1]);
            ori.Show();
            ori.SetMemento(Caretaker.Mementos[2]);
            ori.Show();

            Console.Read();
        }
    }
}
