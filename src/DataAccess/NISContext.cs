using System.Data.Entity;
using System.Data.Entity.Migrations;
using NIS.DataAccess;
using NIS.Domain.Models;
using NIS.Domain.Models.Mapping;

namespace NIS.DataAccess
{
    public class NISContext : DbContext
    {
        string conn;
        
        static NISContext()
        {
            Database.SetInitializer(new MySqlInitializer());
        }

        public NISContext(string host, string user, string password, string dbName)
            : base("Name=AppContext")
        {
            if (conn == null) conn = Database.Connection.ConnectionString;
            Database.Connection.ConnectionString = string.Format(conn, host, user, password, dbName);
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

