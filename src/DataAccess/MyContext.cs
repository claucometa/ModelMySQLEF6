
namespace NIS.DataAccess
{
    public static class MyContext
    {
        public static NISContext db;
        static string _host, _user, _password, _dbName;

        public static void Config(string host, string user, string password, string databaseName)
        {
            _host = host;
            _user = user;
            _password = password;
            _dbName = databaseName;
            db = new NISContext(_host, user, _password, _dbName);
        }

        public static bool HasChanges()
        {
            return db.ChangeTracker.HasChanges();
        }
    }
}
