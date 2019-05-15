using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerDL
{
    public class ImgInfo
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string ImgTitle { get; set; }

        public string ImgContent { get; set; }

        public DateTime ImgDate { get; set; }

        public string ImgPath { get; set; }

        public string ImgType { get; set; }

        public byte[] ImgBytes { get; set; }
    }
}
