namespace Models
{
    public interface IEntity<I> where I : struct
    {
        I ID { get; set; }
    }

    public class Mode : IEntity<int>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int MaxBottleNumber { get; set; }
        public int MaxUsedTips { get; set; }
    }
    public class Step : IEntity<int>
    {
        public int ID { get; set; }
        public Mode Mode { get; set; }
        public int ModeID { get; set; }

        public int Timer { get; set; }
        public int Speed { get; set; }
        public string Type { get; set; }
        public int Volume { get; set; }
    }

    public class Account : IEntity<int>
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
