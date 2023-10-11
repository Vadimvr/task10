using Models;
using System.Collections.Generic;
using System;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace DB
{
    public interface IEntitiesDB<T, I> where T : IEntity<I> where I : struct
    {
        T Get(I id);
        List<T> GetAll();
        void Update(T t);
        void Delete(I id);
        void Add(T t);
    }

    public interface IApplicationDB2<T, I> where T : IEntity<I> where I : struct
    {
        T Get(I id);
        IEnumerable<T> GetAll();
        void Update(T t);
        void Delete(I id);
        void Add(T t);
    }


    public class SQLiteDb<T, I> : IApplicationDB2<T, I> where T : Entity<I> where I : struct
    {
        private AppDbContext context;

        public SQLiteDb(AppDbContext appDbContext)
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
        public  bool Exists(I id)
        {
            return context.Set<T>().Any(e => e.ID.Equals(id));
        }
    }


    public class AppDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Mode> Modes { get; set; }
        public DbSet<Step> Steps { get; set; }



        public AppDbContext(string connectionString) :
            base(
            new SQLiteConnection() { ConnectionString = connectionString }, true)
        {
            Database.SetInitializer<AppDbContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mode>()
                 .HasMany(c => c.Steps);

            base.OnModelCreating(modelBuilder);

        }

    }
}
