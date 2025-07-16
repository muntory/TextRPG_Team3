using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Managers;

namespace TextRPG_Team3.Stat
{
    public class PlayerStatComponent : CharacterStatComponent
    {
        public int MaxMP;
        int mp;
        public int MP
        {
            get { return mp; }
            set { Math.Clamp(value, 0, MaxMP); }
        }

        public double CriticalRate;
        public double DodgeRate;

        public PlayerStatComponent() : base() 
        {
            MaxMP = 50;
            MP = MaxMP;

        }


    }
}
