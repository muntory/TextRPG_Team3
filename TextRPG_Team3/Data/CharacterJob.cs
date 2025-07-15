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
        public int JobAtk { get; set; }
        public int JobHP { get; set; }
        public int JobDef { get; set; }
    }
}
