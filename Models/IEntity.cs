using System.ComponentModel;

namespace Models
{
    public interface IEntity<I> where I : struct
    {
        I ID { get; set; }
    }
}
