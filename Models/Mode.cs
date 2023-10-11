namespace Models
{

    public class Mode : IEntity<int>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int MaxBottleNumber { get; set; }
        public int MaxUsedTips { get; set; }
    }
}
