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
            set { mp = Math.Clamp(value, 0, MaxMP); }
        }

        

        private double expRate;
        public double ExpRate
        {
            get { return expRate; }
            set
            {
                expRate = value;
            }
        }

        private double exp;
        public double Exp
        {
            get { return exp; }
            set
            {
                exp = value * ExpRate;
            }
        }

        public double CriticalRate;
        public double AccuracyRate;
        public double CriticalDamageRate;

        public PlayerStatComponent() : base() 
        {
            MaxMP = 50;
            MP = MaxMP;
            CriticalRate = 0.15;
            AccuracyRate = 0.9;
            CriticalDamageRate = 1.6;
            ExpRate = 1.0;
            Exp = 0.0;
        }


    }
}
