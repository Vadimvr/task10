using DocumentFormat.OpenXml.Office2010.Excel;
using System.ComponentModel;

namespace Models
{
    public interface IEntity<I> where I : struct
    {
        I ID { get; set; }
    }
    public abstract class Entity<I> : IEntity<I> where I : struct
    {
        protected I id;

        [ReadOnly(true)]
        public I ID { get => id; set => id = value; }
    }
}

