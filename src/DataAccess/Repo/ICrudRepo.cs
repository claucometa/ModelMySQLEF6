using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NIS.DataAccess.Repo
{
    public interface ICrudRepo<T> : IViewRepo<T> where T : class
    {
        void Add(T obj);
        void Remove(T obj);
        void Update(T obj);
        void Save();
        void Restore(T item);
        void Restore();
        void Add(IEnumerable<T> objs);
        void Remove(IEnumerable<T> objs);
    }

    public interface IViewRepo<T> where T : class
    {
        T GetById(object id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    }
}
