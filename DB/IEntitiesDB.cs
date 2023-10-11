using Models;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;

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
