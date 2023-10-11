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


   
}
