using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace SQLiteOperate
{
    //[Table("Hero")]
    public class Hero
    {
        //[Key]
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 种族列表 1，2，3，4
        /// </summary>
        public string RaceId { get; set; }
        /// <summary>
        /// 职业列表 1，2，3，4
        /// </summary>
        public string ProfessionId { get; set; }
        public int Fee { get; set; }
        public string Icon { get; set; }
    }

    //[Table("HeroRace")]
    public class HeroRace
    {
        //[Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }

    }

    //[Table("HeroProfession")]
    public class HeroProfession
    {
        //[Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }

    }

}
