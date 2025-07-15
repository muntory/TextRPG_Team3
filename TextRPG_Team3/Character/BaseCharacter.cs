using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Stat;

namespace TextRPG_Team3.Character
{
    public class BaseCharacter
    {
        public string Name { get; set; }

        public Func<int, int> OnHit;
        public bool IsAlive { get; set; }


        public BaseCharacter()
        {
            Name = "Chad";
            IsAlive = true;
        }

    }
}
