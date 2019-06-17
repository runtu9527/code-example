using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Entity;
namespace SqlServer_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //测试

            //EF codefirst 实体数据模型,可以快速建立数据库,数据库操作简单,但是效率较低
            //System.Data.Entity.Database.SetInitializer(new InitImgDB());
            //VideoDb db = new VideoDb();
            //db.ImgInfoes.Where(p => p.UserName == "jiaohongbo").ToList().ForEach(p => p.VideoTitle = "new_video_title");
            
            //db.ImgInfoes.RemoveRange(db.ImgInfoes.Where(p => p.UserName == "jiaohongbo"));
            
            //db.SaveChanges();
            //var nlist = db.ImgInfoes.ToList();
            //nlist.ForEach(p => Console.WriteLine(p.UserName + " " + p.VideoTitle + " " + p.VideoContent + " " + p.VideoType));
            //自定义数据库操作,效率较高
            //int re = DbHelperSQL.ExecuteSql("INSERT INTO ImgInfoes(UserName, Auditing, Flower,MonthSum,PlaySum,Tile,VideoContent,VideoPath,VideoTitle,VideoType,VideoDate) VALUES('jiaohongbo22222', 1, 12,12,12,12,'wefuewi1','###','video','film','" + DateTime.Now + "')");
            //string sqlstr = "select * from ImgInfoes";
            //DataSet data = DbHelperSQL.Query(sqlstr);
            //var list = IListDataSet.DataSetToIList<ImgInfo>(data, 0);
            //list.ToList().ForEach(p => Console.WriteLine(p.UserName + " " + p.VideoTitle + " " + p.VideoContent + " " + p.VideoType));

            //可以使用EF框架去建立数据库,然后自定义数据库操作进行增删改查,综合效率较高
            Console.ReadLine();
        }
    }

    
}
