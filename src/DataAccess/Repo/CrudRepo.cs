using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIS.DataAccess.Repo
{
    public class CrudRepo<T> : ViewRepo<T>, ICrudRepo<T> where T : class
    {
        public CrudRepo()
        {
            table = db.Set<T>();
        }

        public void Restore(T item)
        {
            db.Entry(item).Reload();
        }

        public bool HasChanges()
        {            
            return db.ChangeTracker.HasChanges();
        }

        public void Restore()
        {
            foreach (DbEntityEntry entry in db.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                    default: break;
                }
            }
        }

        public virtual void Add(T obj)
        {
            table.Add(obj);
        }

        public virtual void Add(IEnumerable<T> objs)
        {
            table.AddRange(objs);
        }

        public virtual void Remove(T obj)
        {
            var entry = db.Entry(obj);
            table.Attach(obj);            
            entry.State = EntityState.Deleted;
        }

        public virtual void Remove(IEnumerable<T> objs)
        {
            var total = objs.Count();
            for (int i = 0; i < total; i++)
            {
                Remove(objs.ElementAt(i));
            }
        }

        public virtual void Update(T obj)
        {
            var entry = db.Entry(obj);
            table.Attach(obj);
            entry.State = EntityState.Modified;
        }

        public virtual void Save()
        {            
            db.SaveChanges();
        }
    }
}
