using SqlServerDL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SqlTest_WPF
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //install-package entityframework
            System.Data.Entity.Database.SetInitializer(new InitImgDB());
            base.OnStartup(e);
        }
    }
}
