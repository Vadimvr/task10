namespace Models
{
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
}
