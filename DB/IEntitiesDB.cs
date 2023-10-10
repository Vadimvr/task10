using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DB
{
    public interface IEntitiesDB<T, I> where T : IEntity<I> where I : struct
    {
        T Get(I id);
        List<T> GetAll();
        void Update(T t);
        void Delete(T t);
        void Add(T t);
    }

    public class EntitiesDB<T, I> : IEntitiesDB<T, I> where T : IEntity<I> where I : struct
    {
        private List<T> entities;

        public EntitiesDB(List<T> arr) { entities = arr; }
        public void Add(T t) => entities.Add(t);
        public void Delete(T t) => entities.Remove(t);
        public T Get(I id) => entities.FirstOrDefault(i => i.ID.Equals(id));
        public List<T> GetAll() => entities;
        public void Update(T t)
        {
            T item = default(T);
            int i = 0;
            for (; i < entities.Count; i++)
            {
                item = entities.First(e => e.ID.Equals(t.ID));
            }
            if (item == null) throw new ArgumentNullException();

            entities[i] = t;
        }
    }
}
