using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team3.Data
{
    internal class CharacterJob
    {
        public int JobID { get; set; }
        public string JobName { get; set; }
        public double JobAtk { get; set; }
        public int JobHP { get; set; }
        public int JobMP { get; set; }

        public double JobDef { get; set; }
        public double CriticalRate { get; set; }
        public double CriticalDamageRate { get; set; }

        public double AccuracyRate { get; set; }
        public List<int> BaseSkillSet { get; set; }

    }
}
