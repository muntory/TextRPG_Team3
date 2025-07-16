using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team3.Data
{
    public class KillEnemyQuest : IQuest
    {
        public int GoalEnemyID {  get; set; }
        public int CurrentAmount { get; set; }
        public int GoalAmount {  get; set; }

        public bool isCompleted => CurrentAmount >= GoalAmount;
        public KillEnemyQuest(int goalEnemyID, int goalAmount)
        {
            GoalEnemyID = goalEnemyID;
            GoalAmount = goalAmount;
            CurrentAmount = 0;
        }

        public void OnEnemyKilled(int enemyID)
        {
            if (enemyID == GoalEnemyID)
            {
                CurrentAmount++;
            }
        }
    }
}
