using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team3.Item
{
    public class Badge
    {
        public int[] Effects;
        public int Rarity = 0;
        public string Name;
        public Badge(string Name = null) 
        { 
            this.Name = Name;
        }
        
    }
}
