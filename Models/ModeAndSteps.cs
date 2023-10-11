namespace Models
{
    public class ModeAndSteps
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int MaxBottleNumber { get; set; }
        public int MaxUsedTips { get; set; }
        public int ModeID { get; set; }

        public int Timer { get; set; }
        public int Speed { get; set; }
        public string Type { get; set; }
        public int Volume { get; set; }
        public ModeAndSteps(Mode mode, Step step)
        {
            ID = step.ID;
            Name = mode.Name;
            MaxBottleNumber = mode.MaxBottleNumber;
            MaxUsedTips = mode.MaxUsedTips;
            ModeID = mode.ID;
            Timer = step.Timer;
            Speed = step.Speed;
            Type = step.Type;
            Volume = step.Volume;
        }
    }
}
