using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team3.Data
{
    internal class QuestData
    {
        public int ID { get; set; }
        public string QuestName { get; set; }
        public string QuestDescription { get; set; }
        public int GoldReward {  get; set; }
        public bool isAccepted {  get; set; }
        public bool isCleared {  get; set; }
    }
}
