using System;
using TextRPG_Team3.Character;
using TextRPG_Team3.Data;
using TextRPG_Team3.Stat;

namespace TextRPG_Team3.Managers
{
	public class GameManager
	{
		private static GameManager instance;
		public static GameManager Instance { get { return instance; } }

        // 플레이어
        public PlayerCharacter Player;

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

        public void MaxExperience()
        {
            List<int> MaxExperienceLevel = new List<int> { 10, 35, 65, 100 };

            CharacterStatComponent stat = GameManager.Instance.Player.Stat;
            int exp = SpawnManager.Instance.SumofEnemyLevel();
            stat.exp += exp;
            while (true)
            {
                if (stat.Level < MaxExperienceLevel.Count && stat.exp >= MaxExperienceLevel[stat.Level - 1])
                {
                    stat.Level += 1;
                    stat.BaseDefense += 1.0;
                    stat.BaseAttack += 0.5;
                    Console.WriteLine("============== Level Up ==============\n");
                    Console.WriteLine($"축하합니다 레벨업하셨습니다!");
                    Console.WriteLine($"Lv. {stat.Level-1} Chad -> Lv. {stat.Level} Chad");
                    Console.WriteLine("기본공격력 0.5 방어력 1이 증가하셨습니다\n");
                    Console.WriteLine("============== Level Up ==============\n");
                    break;
                }

            }
            

        }


    }
}