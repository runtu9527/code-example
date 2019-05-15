using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeTest
{
    class Resume : ICloneable
    {
        private string _name;
        private Work _work;

        public Resume()
        {
            _work = new Work();
        }
        public void SetName(string name)
        {
            this._name = name;
        }

        public void SetWorkExperience(string company,string position)
        {
            this._work.Company = company;
            this._work.Position = position;
        }

        public void Display()
        {
            Console.WriteLine("{0},{1},{2}", _name, _work.Company, _work.Position);
        }

        public object Copy()
        {
            Resume obj = new Resume();
            //先进行浅复制,将所有的数据复制过来
            obj = (Resume)this.MemberwiseClone();
            //再对当前类中的引用对象进行浅复制
            obj._work = (Work)this._work.Clone();
            //直到没有引用对象为止
            return obj;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public class Work:ICloneable
    {
        public string Company { get; set; }
        public string Position { get; set; }


        //浅复制
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}