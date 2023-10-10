using Models;
using System.Collections.Generic;
using System.Data;

namespace DB
{
    public interface IApplicationDB
    {
        EntitiesDB<Account> Accounts { get; set; }
        EntitiesDB<Mode> Modes { get; set; }
        EntitiesDB<Step> Steps { get; set; }
    }

    public interface EntitiesDB<T> where T : class
    {
        T Get(int id);
        List<T> GetAll();
        void Update(T t);
        void Delete(T t);
        void Add(T t);
    }
}
