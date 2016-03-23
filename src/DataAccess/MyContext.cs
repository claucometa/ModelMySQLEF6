
namespace NIS.DataAccess
{
    public static class MyContext
    {
        public static NISContext db;

        public static void Config(string host, string user, string password, string dbName)
        {
            db = new NISContext(host, user, password, dbName);
        }

        public static bool HasChanges()
        {
            return db.ChangeTracker.HasChanges();
        }
    }
}
