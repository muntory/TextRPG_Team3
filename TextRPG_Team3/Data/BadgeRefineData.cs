using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team3.Data
{
    public class BadgeRefineData
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public Enums.StatType StatType { get; set; }
        public double Value { get; set; }
        public bool IsPercent { get; set; }
        public double Chance { get; set; }
        public int Rarity { get; set; }
    }
}
