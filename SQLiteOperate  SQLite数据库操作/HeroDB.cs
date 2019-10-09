using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.IO;
using System.Linq;

namespace SQLiteOperate
{
    public class RetailContext : DbContext
    {
        public RetailContext()
            : base("Hero")
        {
        }
        public DbSet<Hero> Heros { set; get; }
        public DbSet<HeroRace> HeroRace { set; get; }
        public DbSet<HeroProfession> HeroProfession { set; get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //移除TableName自动添加复数
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
    public class HeroDB : DropCreateDatabaseIfModelChanges<RetailContext>
    {
        private static string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "hero.db");
        private static SQLiteDBHelper db = new SQLiteDBHelper(dbPath);

        protected override void Seed(RetailContext context)
        {
            base.Seed(context);
        }
        static HeroDB()
        {
            if (!File.Exists(dbPath))
            {
                db.CreateDb(dbPath);

                db.CreateTable(@"CREATE TABLE [Hero] (
                              [Id] INTEGER NOT NULL PRIMARY KEY, 
                              [Name] VARCHAR(50) NOT NULL, 
                              [RaceId] VARCHAR(50) NOT NULL, 
                              [ProfessionId] VARCHAR(50) NOT NULL, 
                              [Fee] INTEGER NOT NULL, 
                              [Icon] VARCHAR(50));");

                db.CreateTable(@"CREATE TABLE [HeroRace] (
                              [Id] INTEGER NOT NULL PRIMARY KEY, 
                              [Name] VARCHAR(50) NOT NULL, 
                              [Icon] VARCHAR(50));");

                db.CreateTable(@"CREATE TABLE [HeroProfession] (
                              [Id] INTEGER NOT NULL PRIMARY KEY, 
                              [Name] VARCHAR(50) NOT NULL, 
                              [Icon] VARCHAR(50));");

                InitTable();
            }
        }

        private static void InitTable()
        {
            using (RetailContext context = new RetailContext())
            {
                List<Hero> heros = new List<Hero>();
                context.Heros.AddRange(heros);

                List<HeroRace> heroRaces = new List<HeroRace>();
                context.HeroRace.AddRange(heroRaces);

                List<HeroProfession> heroProfessions = new List<HeroProfession>();
                context.HeroProfession.AddRange(heroProfessions);

                context.SaveChanges();
            }
        }
    }
}
