using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Managers;

namespace TextRPG_Team3.Data
{
    public class LevelUpQuest : IQuest
    {
        public int GoalLevel {  get; set; }
        public int CurrentLevel { get; set; }

        public bool IsCompleted => CurrentLevel >= GoalLevel;
        public LevelUpQuest(int goal)
        {
            GoalLevel = goal;
            if(GameManager.Instance.Player.Stat.Level == 0)
            {
                CurrentLevel = 1;
            }
            else
            {
                CurrentLevel = GameManager.Instance.Player.Stat.Level;
            }
        }

        public void OnLevelUp()
        {
            CurrentLevel++;
        }
    }
}
