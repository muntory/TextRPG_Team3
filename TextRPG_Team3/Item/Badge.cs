using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team3.Item
{
    public class Badge
    {
        public int[] Effects { get; set; }
        public int Rarity { get; set; }
        public string Name { get; set; }
        public Badge(string Name = null) 
        { 
            this.Name = Name;
        }
        
    }
}
