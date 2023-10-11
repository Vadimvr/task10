using ClosedXML.Excel;
using System;
using System.ComponentModel;

namespace Models
{
    public class Step : Entity<int>
    {
        private Mode mode;
        private int modeID;
        private int timer;
        private int speed;
        private string _type;
        private int volume;
        private string destination;

        public new int ID { get => base.ID; set { base.ID = value; } }
        [Browsable(false)]
        public Mode Mode { get => mode; set => mode = value; }
        public int ModeID { get => modeID; set => modeID = value; }
        public int Timer { get => timer; set => timer = value; }
        public string Destination { get => destination; set => destination = value; }
        public int Speed { get => speed; set => speed = value; }
        public string Type { get => _type; set => _type = value; }
        public int Volume { get => volume; set => volume = value; }

        public override string ToString()
        {
            return $"{id} {modeID} {timer} {destination} {speed} {_type} {volume}";
        }
        public static Step ConvertToMode(IXLRow iXLRow)
        {
            Step step = new Step();
            int i = 1;
            string id = iXLRow.Cell(i++).Value.ToString();
            string modeID = iXLRow.Cell(i++).Value.ToString();
            string timer = iXLRow.Cell(i++).Value.ToString();
            string destination = iXLRow.Cell(i++).Value.ToString();
            string speed = iXLRow.Cell(i++).Value.ToString();
            string _type = iXLRow.Cell(i++).Value.ToString();
            string volume = iXLRow.Cell(i++).Value.ToString();

            if (!int.TryParse(id, out step.id)) throw new ArgumentException(nameof(id));
            if (!int.TryParse(modeID, out step.modeID)) throw new ArgumentException(nameof(modeID));
            if (!int.TryParse(timer, out step.timer)) throw new ArgumentException(nameof(timer));
            step.destination = destination;
            if (!int.TryParse(speed, out step.speed)) throw new ArgumentException(nameof(speed));
            if (string.IsNullOrWhiteSpace(_type)) throw new ArgumentException(nameof(_type));
            step._type = _type;
            if (!int.TryParse(volume, out step.volume)) throw new ArgumentException(nameof(volume));

            return step;
        }
    }
}
