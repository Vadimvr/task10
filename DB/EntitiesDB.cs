using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DB
{
    public class EntitiesDB<T, I> : IEntitiesDB<T, I> where T : IEntity<I> where I : struct
    {
        private List<T> entities;

        public EntitiesDB(List<T> arr) { entities = arr; }
        public void Add(T t) => entities.Add(t);
        public void Delete(I id)
        {
            T e = entities.FirstOrDefault(i => i.ID.Equals(id));
            if (e != null)
            {
                entities.Remove(e);
            }
            else
            {
                throw new Exception();
            }
        }
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
