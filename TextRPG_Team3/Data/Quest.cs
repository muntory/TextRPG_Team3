using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team3.Data
{
    internal class Quest
    {
        public int ID { get; set; }
        public string QuestName { get; set; }
        public string QuestDescription { get; set; }
        public int GoldReward { get; set; }
        public bool isAccepted {  get; set; }
        public string QuestType {  get; set; }
        public QuestGoalData GoalData { get; set; }
        
        public IQuest Goal;
        public bool IsCompleted => Goal.isCompleted;
    }
}
