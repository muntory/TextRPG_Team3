using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Stat;

namespace TextRPG_Team3
{

    public enum ItemType
    {
        Weapon,
        Armor,
        Shield,
        Consumable,
    }
    public class ItemData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public Enums.StatType StatType { get; set; }
        public int Value { get; set; }

        public string Description { get; set; }
    }
}
