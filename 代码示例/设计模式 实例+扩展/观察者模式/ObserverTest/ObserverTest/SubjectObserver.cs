using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverTest
{
    public class SubjectObserver : IBaseSubjectModel
    {
        public string Name { get; set; }
        
        public event SubjectEventHandler ObserverEvent;
        
        public void Notify(int mode, object data)
        {
            if (ObserverEvent != null)
            {
                ObserverEvent(mode, data);
            }
        }

    }
}
