using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SqlServerDL;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
namespace SqlTest_WPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //EF codefirst 实体数据模型,可以快速建立数据库,数据库操作简单,但是效率较低
            ImgDB db = new ImgDB();
            db.ImgTables.Where(p => p.UserName == "jiaohongbo").ToList().ForEach(p => p.ImgTitle = "new_video_title");
            //db.ImgInfoes.RemoveRange(db.ImgInfoes.Where(p => p.UserName == "jiaohongbo"));
            db.SaveChanges();
            var nlist = db.ImgTables.ToList();
            nlist.ForEach(p => Console.WriteLine(p.UserName + " " + p.ImgTitle + " " + p.ImgContent + " " + p.ImgPath));


            //自定义数据库操作,效率较高
            //int re = DbHelperSQL.ExecuteSql("INSERT INTO ImgInfoes(UserName, Auditing, Flower,MonthSum,PlaySum,Tile,VideoContent,VideoPath,VideoTitle,VideoType,VideoDate) VALUES('jiaohongbo22222', 1, 12,12,12,12,'wefuewi1','###','video','film','" + DateTime.Now + "')");
            //string sqlstr = "select * from ImgInfoes";
            //DataSet data = DbHelperSQL.Query(sqlstr);
            //var list = IListDataSet.DataSetToIList<ImgInfo>(data, 0);
            //list.ToList().ForEach(p => Console.WriteLine(p.UserName + " " + p.VideoTitle + " " + p.VideoContent + " " + p.VideoType));

            //可以使用EF框架去建立数据库,然后自定义数据库操作进行增删改查,综合效率较高
        }
        public string Remark { get; set; }
    }
   
}
