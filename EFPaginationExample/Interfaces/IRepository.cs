using System;
using System.Collections.Generic;

namespace EFPaginationExample.Interfaces
{
    public interface IRepository<T> where T : class, IDbEntity
    {
        int Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T SelectById(int id);
        List<T> Select(Func<T, bool> filter);
        bool Any();
        bool Any(Func<T, bool> filter);
        List<T> SelectAll();
        List<T> SelectPagedData(int page, int perPage, Func<T, bool> filter, Func<T, object> order);
    }
}
