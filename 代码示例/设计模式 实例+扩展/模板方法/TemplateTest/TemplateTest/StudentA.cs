using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateTest
{
    /// <summary>
    /// 不同子类,实现不同的细节
    /// </summary>
    class StudentA:TestPaper
    {
        public override string Answer1()
        {
            return "A";
        }

        public override string Answer2()
        {
            return "B";
        }
    }
}
