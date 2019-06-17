namespace SqlServerDL
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ImgDB : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“ImgDB”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“SqlServerDL.ImgDB”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“ImgDB”
        //连接字符串。
        public ImgDB()
            : base("name=ImgDB")
        {
        }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        public virtual DbSet<ImgInfo> ImgTables { get; set; }
    }

    public class InitImgDB : DropCreateDatabaseAlways<ImgDB>
    {
        protected override void Seed(ImgDB context)
        {
            context.ImgTables.Add(new ImgInfo { UserName = "jiaohongbo", ImgTitle = "imgtitle", ImgContent = "wefuewi1", ImgPath = "#", ImgType = "film", ImgDate = DateTime.Now });
            context.ImgTables.Add(new ImgInfo { UserName = "jiaohongbo", ImgTitle = "imgtitle", ImgContent = "wefuewi2", ImgPath = "#", ImgType = "hnmour", ImgDate = DateTime.Now });
            context.ImgTables.Add(new ImgInfo { UserName = "jiaohongbo", ImgTitle = "imgtitle", ImgContent = "wefuewi3", ImgPath = "#", ImgType = "cartoon", ImgDate = DateTime.Now });
            context.ImgTables.Add(new ImgInfo { UserName = "jiaohongbo", ImgTitle = "imgtitle", ImgContent = "wefuewi4", ImgPath = "#", ImgType = "sport", ImgDate = DateTime.Now });
            context.ImgTables.Add(new ImgInfo { UserName = "jiaohongbo", ImgTitle = "imgtitle", ImgContent = "wefuewi5", ImgPath = "#", ImgType = "film", ImgDate = DateTime.Now });
            context.ImgTables.Add(new ImgInfo { UserName = "jiaohongbo", ImgTitle = "imgtitle", ImgContent = "wefuewi6", ImgPath = "#", ImgType = "cartoon", ImgDate = DateTime.Now });
            context.ImgTables.Add(new ImgInfo { UserName = "jiaohongbo", ImgTitle = "imgtitle", ImgContent = "wefuewi7", ImgPath = "#", ImgType = "sport", ImgDate = DateTime.Now });
            base.Seed(context);
        }
    }

    public class ResetImgDB : DropCreateDatabaseIfModelChanges<ImgDB>
    {
        protected override void Seed(ImgDB context)
        {
            context.ImgTables.Add(new ImgInfo { UserName = "jiaohongbo", ImgTitle = "imgtitle", ImgContent = "wefuewi1", ImgPath = "#", ImgType = "film", ImgDate = DateTime.Now });
            context.ImgTables.Add(new ImgInfo { UserName = "jiaohongbo", ImgTitle = "imgtitle", ImgContent = "wefuewi2", ImgPath = "#", ImgType = "hnmour", ImgDate = DateTime.Now });
            context.ImgTables.Add(new ImgInfo { UserName = "jiaohongbo", ImgTitle = "imgtitle", ImgContent = "wefuewi3", ImgPath = "#", ImgType = "cartoon", ImgDate = DateTime.Now });
            context.ImgTables.Add(new ImgInfo { UserName = "jiaohongbo", ImgTitle = "imgtitle", ImgContent = "wefuewi4", ImgPath = "#", ImgType = "sport", ImgDate = DateTime.Now });
            context.ImgTables.Add(new ImgInfo { UserName = "jiaohongbo", ImgTitle = "imgtitle", ImgContent = "wefuewi5", ImgPath = "#", ImgType = "film", ImgDate = DateTime.Now });
            context.ImgTables.Add(new ImgInfo { UserName = "jiaohongbo", ImgTitle = "imgtitle", ImgContent = "wefuewi6", ImgPath = "#", ImgType = "cartoon", ImgDate = DateTime.Now });
            context.ImgTables.Add(new ImgInfo { UserName = "jiaohongbo", ImgTitle = "imgtitle", ImgContent = "wefuewi7", ImgPath = "#", ImgType = "sport", ImgDate = DateTime.Now });
            base.Seed(context);
        }
    }

}