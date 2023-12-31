﻿using Models;
using System.Data.Entity;
using System.Data.SQLite;

namespace DB
{
    public class AppDbContext : DbContext, IAppDbContext
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
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
