using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team3.Data
{
    public class KillEnemyQuest : IQuest
    {
        public int GoalEnemyTier {  get; set; }
        public int CurrentAmount { get; set; }
        public int GoalAmount {  get; set; }

        public bool IsCompleted => CurrentAmount >= GoalAmount;
        public KillEnemyQuest(int goalEnemyTier, int goalAmount)
        {
            GoalEnemyTier = goalEnemyTier;
            GoalAmount = goalAmount;
            CurrentAmount = 0;
        }

        public void OnEnemyKilled(int enemyTier)
        {
            if (enemyTier == GoalEnemyTier)
            {
                CurrentAmount++;
            }
        }
    }
}
