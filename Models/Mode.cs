using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Models
{

    public class Mode : Entity<int>
    {
        private string name;
        private int maxBottleNumber;
        private int maxUsedTips;

        public new int ID { get => base.ID; set { base.ID = value; } }
        public ICollection<Step> Steps { get; set; }
        public string Name { get => name; set => name = value; }
        public int MaxBottleNumber { get => maxBottleNumber; set => maxBottleNumber = value; }
        public int MaxUsedTips { get => maxUsedTips; set => maxUsedTips = value; }

        public static Mode ConvertToMode(string id, string Name, string maxBottleNumber, string maxUsedTips)
        {
            return new Mode();
        }

        public override string ToString()
        {
            return $"{id} {name} {maxBottleNumber} {maxUsedTips}";
        }

        public static Mode ConvertToMode(ClosedXML.Excel.IXLRow iXLRow)
        {
            Mode mode = new Mode();
            string id = iXLRow.Cell(1).Value.ToString();
            string name = iXLRow.Cell(2).Value.ToString();
            string maxBottleNumber = iXLRow.Cell(3).Value.ToString();
            string maxUsedTips = iXLRow.Cell(4).Value.ToString();

            if (!int.TryParse(id, out mode.id)) throw new ArgumentException(nameof(id));
            if (!int.TryParse(maxBottleNumber, out mode.maxBottleNumber)) throw new ArgumentException(nameof(maxBottleNumber));
            if (!int.TryParse(maxUsedTips, out mode.maxUsedTips)) throw new ArgumentException(nameof(maxUsedTips));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(nameof(name));
            mode.name = name;
            return mode;
        }
    }
}
