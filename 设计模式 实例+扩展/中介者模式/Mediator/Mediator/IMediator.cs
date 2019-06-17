using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    /// <summary>
    /// 抽象中介者接口
    /// </summary>
    interface IMediator
    {
        object data { get; set; }
        //List<IColleague> Colleagues { get; set; }
        ObservableCollection<IColleague> Colleagues { get; set; }

        void Registor(IColleague colleague);
        void UnRegistor(IColleague colleague);
        void SendMessage(int mode, object msg);
        void TargetColleagueReceive(int targetmode, int mode, object data);
        IColleague FindColleague(IColleague colleague);
        IColleague FindColleague(int mode);

    }
}
