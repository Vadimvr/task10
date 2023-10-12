using Models;
using System.Data.Entity;

namespace DB
{
    public interface IAppDbContext
    {
        DbSet<Account> Accounts { get; set; }
        DbSet<Mode> Modes { get; set; }
        DbSet<Step> Steps { get; set; }
        int SaveChanges();
    }
}