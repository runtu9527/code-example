using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace WCF_Client
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private MyCallBack callback = null;
        InstanceContext ic = null;
        MessageService.MessageServiceClient mc = null;
        NormalService.NormalServiceClient nc = null;
        public MainWindow()
        {
            InitializeComponent();

            callback = new MyCallBack();
            ic = new InstanceContext(callback);
            mc = new MessageService.MessageServiceClient(ic);
            //mc.Regist();
            nc = new NormalService.NormalServiceClient();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mc.SendToAll("111", "222");
            //MessageBox.Show("客户端调用服务器成功");
            Console.WriteLine("客户端调用服务器成功");
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            string result = nc.Show("jiaohongbo");
            MessageBox.Show(result);
        }
    }

    public class MyCallBack : MessageService.IMessageServiceCallback
    {
        public void Show()
        {
            //MessageBox.Show("服务器调用客户端成功");
            Console.WriteLine("服务器调用客户端成功");
            //return;
        }
    }
}
