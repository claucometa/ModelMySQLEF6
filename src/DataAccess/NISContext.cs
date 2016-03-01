using System.Data.Entity;
using System.Data.Entity.Migrations;
using NIS.DataAccess;
using NIS.Domain.Models;
using NIS.Domain.Models.Mapping;

namespace NIS.DataAccess
{
    public class NISContext : DbContext
    {
        static NISContext()
        {
            Database.SetInitializer(new MySqlInitializer());
        }

        public static void SetDataBaseOptions(string host, string user, string password, string databaseName)
        {
            Properties.Settings.Default.host = host;
            Properties.Settings.Default.user = user;
            Properties.Settings.Default.password = password;
            Properties.Settings.Default.databaseName = databaseName;
            Properties.Settings.Default.Save();
        }

        public NISContext()
            : base("Name=AppContext")
        {
            var host = Properties.Settings.Default.host;
            var user = Properties.Settings.Default.user;
            var password = Properties.Settings.Default.password;
            var databaseName = Properties.Settings.Default.databaseName;
            Database.Connection.ConnectionString = string.Format(Database.Connection.ConnectionString,
                host, user, password, databaseName);
        }

        // Tables
        public DbSet<Setting> Settings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Settings
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            // Mapping
            modelBuilder.Configurations.Add(new SettingMap());

            base.OnModelCreating(modelBuilder);
        }

        public static void InitSeed(NISContext context)
        {
            //context.TableName.AddOrUpdate(Seed.SeedExams(context));
            //context.SaveChanges();            
        }
    }
}

