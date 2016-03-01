
namespace NIS.DataAccess
{
    public static class MyContext
    {
        public static EletricBillContext db = new EletricBillContext();
        //const string conn = "server={0};user id={1};password={2};persistsecurityinfo=True;database=EletricBills";
        //const string conn = @"DRIVER={MySQL ODBC 3.51 Driver}; SERVER={0}; PORT=3306; database=EletricBills; USER={1}; PASSWORD={2}; OPTION=0;";

        public static void ConfigServer(string server, string user, string pass)
        {
            //db.Database.Connection.ConnectionString = string.Format(
            //    conn, server, user, pass);            
            db.Database.Initialize(true);
        }

        public static bool HasChanges()
        {
            return db.ChangeTracker.HasChanges();
        }
    }
}
