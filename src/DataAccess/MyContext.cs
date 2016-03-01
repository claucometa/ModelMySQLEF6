
namespace NIS.DataAccess
{
    public static class MyContext
    {
        public static NISContext db = new NISContext();

        public static bool HasChanges()
        {
            return db.ChangeTracker.HasChanges();
        }
    }
}
