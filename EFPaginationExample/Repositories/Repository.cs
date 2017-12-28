using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EFPaginationExample.Interfaces;

namespace EFPaginationExample.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IDbEntity
    {
        public int Add(T entity)
        {
            using (var context = new EfContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
                return entity.Id;
            }
        }


        public void Update(T entity)
        {
            using (var context = new EfContext())
            {
                context.Set<T>().Attach(entity);
                context.Entry<T>(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (var context = new EfContext())
            {
                context.Set<T>().Attach(entity);
                context.Entry<T>(entity).State = EntityState.Deleted;
                context.SaveChanges();
            }

        }

        public T SelectById(int id)
        {
            using (var context = new EfContext())
            {
                var result = context.Set<T>();
                return result.FirstOrDefault(x => x.Id == id);
            }
        }

        public List<T> Select(Func<T, bool> filter)
        {
            using (var context = new EfContext())
            {
                var result = context.Set<T>();
                return result.Where(filter).ToList();
            }
        }

        public bool Any()
        {
            using (var context = new EfContext())
            {
                var result = context.Set<T>();
                return result.Any();
            }
        }

        public bool Any(Func<T, bool> filter)
        {
            using (var context = new EfContext())
            {
                var result = context.Set<T>();
                return result.Where(filter).Any();
            }
        }

        public List<T> SelectAll()
        {
            using (var context = new EfContext())
            {
                var result = context.Set<T>();
                return result.ToList();
            }
        }

        public List<T> SelectPagedData(int page, int pageSize, Func<T, bool> filter, Func<T, object> order)
        {
            using (var context = new EfContext())
            {
                var result = context.Set<T>()
                    .Where(filter)
                    .OrderBy(order)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                return result;
            }
        }
    }
}