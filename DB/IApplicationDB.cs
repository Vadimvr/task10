using Models;
using System.Collections.Generic;

namespace DB
{
    public interface IApplicationDB<T, I> where T : IEntity<I> where I : struct
    {
        T Get(I id);
        IEnumerable<T> GetAll();
        void Update(T t);
        void Delete(I id);
        void Add(T t);
    }
}
