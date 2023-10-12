using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DB
{
    public class DbSQLite<T, I> : IApplicationDB<T, I> where T : Entity<I> where I : struct
    {
        private AppDbContext context;

        public DbSQLite(AppDbContext appDbContext)
        {
            context = appDbContext;

        }

        public void Add(T t)
        {
            context.Set<T>().Add(t);
            context.SaveChanges();
        }

        public void Delete(I id)
        {
            var entity = context.Set<T>().Find(id);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

        public T Get(I id)
        {
            T res = context.Set<T>().FirstOrDefault(t => t.ID.Equals(id));
            return res;
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>();
        }

        public void Update(T t, I id)
        {

            IEnumerable<T> arr = context.Set<T>();
            T old = null;
            foreach (var item in arr)
            {
                if (item.ID.Equals(t.ID))
                {
                    old = item;
                    break;
                }
            }

            if (old != null)
            {
                context.Set<T>().AddOrUpdate(t);
                context.SaveChanges() ;
            }
        }
        public bool Exists(I id)
        {
            return context.Set<T>().Any(e => e.ID.Equals(id));
        }
    }
}
