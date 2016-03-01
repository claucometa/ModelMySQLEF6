using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace NIS.DataAccess
{
    public class MySqlInitializer : IDatabaseInitializer<NISContext>
    {
        public void InitializeDatabase(NISContext context)
        {
            if (!context.Database.Exists())
            {
                // if database did not exist before - create it
                context.Database.Create();
                NISContext.InitSeed(context);
            }       
        }
    }
}