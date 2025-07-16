using System;
using TextRPG_Team3.Character;

namespace TextRPG_Team3.Managers
{
	public class GameManager
	{
		private static GameManager instance;
		public static GameManager Instance { get { return instance; } }

        // 플레이어
        public PlayerCharacter Player;
        public bool Victory;
        public bool Lose;
       
        public GameManager()
		{
			if (instance == null)
			{
				instance = this;
			}
		}
        public bool CheckVictory(List<EnemyCharacter> enemies)
        {
            foreach (var enemy in enemies)
            {
                if (enemy.IsAlive)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckLose()
        {
            if (GameManager.Instance.Player.PlayerStat.Health == 0)
            {
                return true;
            }
            {
                return false;
            }
        }
    }
}