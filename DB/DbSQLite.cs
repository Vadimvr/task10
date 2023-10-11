using Models;
using System;
using System.Collections.Generic;
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
            return context.Set<T>().FirstOrDefault(t => t.ID.Equals(id));
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>();
        }

        public void Update(T t)
        {
            if (t != null && Exists(t.ID))
            {
                throw new NotImplementedException();
                //context.Set<T>() .Updade(t).State = EntityState.Modified;
                //context.SaveChanges();
            }
        }
        public bool Exists(I id)
        {
            return context.Set<T>().Any(e => e.ID.Equals(id));
        }
    }
}
