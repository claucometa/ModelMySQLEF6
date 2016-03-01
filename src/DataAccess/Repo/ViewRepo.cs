
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace NIS.DataAccess.Repo
{
    public class ViewRepo<T> : IViewRepo<T> where T : class
    {
        public DbSet<T> table;
        public EletricBillContext db = MyContext.db;

        public ViewRepo()
        {
            table = db.Set<T>();
        }

        public virtual T GetById(object id)
        {
            return table.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return table;
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return table.Where(predicate);
        }
    }
}

