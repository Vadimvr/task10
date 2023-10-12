using Models;
using System.Collections.Generic;

namespace DB
{
    public interface IApplicationDB<T, I> where T : Entity<I> where I : struct
    {
        T Get(I id);
        IEnumerable<T> GetAll();
        void Update(T t, I id);
        void Delete(I id);
        void Add(T t);
    }
}
