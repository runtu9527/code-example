using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverTest
{
    public delegate void SubjectEventHandler(int mode,object data);
    /// <summary>
    /// 主题/抽象通知者
    /// </summary>
    public interface IBaseSubjectModel
    {
        string Name { get; set; }

        event SubjectEventHandler ObserverEvent;

        void Notify(int mode, object data);

    }
}
