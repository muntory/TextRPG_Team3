using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Stat;

using static Enums;

namespace TextRPG_Team3
{


    public class ItemData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public Enums.StatType StatType { get; set; }
        public int Value { get; set; }
        public bool IsEquipped { get; set; }

        public string Description { get; set; }
    }
}