using System.Data.Entity;
using System.Data.Entity.Migrations;
using NIS.DataAccess;
using NIS.Domain.Models;
using NIS.Domain.Models.Mapping;

namespace NIS.DataAccess
{
    // [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public partial class EletricBillContext : DbContext
    {
        static EletricBillContext()
        {
            // DbConfiguration.SetConfiguration(new MySql.Data.Entity.MySqlEFConfiguration());
            Database.SetInitializer(new MySqlInitializer());
        }

        public EletricBillContext()
            : base("Name=AppContext") 
        {
        //    Database.Connection.ConnectionString = conn;
        }

        public DbSet<Setting> Settings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new SettingMap());
            
            // Settings
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            base.OnModelCreating(modelBuilder);
        }

        public static void InitSeed(EletricBillContext context)
        {
            //context.Exams.AddOrUpdate(Seed.SeedExams(context));
            //context.Sinonimos.AddOrUpdate(Seed.SeedSinonyms(context));
            //context.SaveChanges();            
        }
    }
}

