using System;
using System.Collections.Generic;
using System.Linq;
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

namespace 调用JavaScript
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    [System.Runtime.InteropServices.ComVisibleAttribute(true)] 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Javascript API 只能在线使用  需要什么功能,只需要复制对应的网页
            string str_url = Environment.CurrentDirectory + "\\AMap.html";
            Uri url = new Uri(str_url);
            webBrowser.Navigate(url);
            //webBrowser.ObjectForScripting = helper;
            //helper.HtmlCmd("DrawPoint");
            object returnvalue = EXEC_JS(webBrowser, "js_fun|参数字符串");
            MessageBox.Show("js方法返回值是：" + returnvalue.ToString());
        }

        private object EXEC_JS(System.Windows.Controls.WebBrowser webBrowser, string tag)
        {
            string[] args = tag.Split('|');
            if (args.Length == 1)
            {
                return webBrowser.Document.(args[0], null);
            }
            else
            {
                object[] objects = new object[args.Length - 1];
                Array.Copy(args, 1, objects, 0, objects.Length);
                return webBrowser.Document.InvokeScript(args[0], objects);
            }
        }
    }
}
