using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team3.Data
{
    public class SkillData
    {
        public int ID { get; set; }
        public string SkillName { get; set; }
        public int CostValue { get; set; }
        public double Multiplier { get; set; }
        public int TargetCount { get; set; }
        public string Description { get; set; }
        public bool RandomAttack { get; set; }
        public bool IsTargetAll { get; set; }

    }
}
