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



            List<int> MaxExperienceLevel = new List<int> { 10, 35, 65, 100 }; // 2~5레벨까지 

            CharacterStatComponent stat = GameManager.Instance.Player.Stat;
            PlayerCharacter CharName = GameManager.Instance.Player;
            while (true)
            {
                double nextLevelExp;

                if (stat.Level <= MaxExperienceLevel.Count)// List에 있는 메모리보다 작거나 같을때
                {
                    nextLevelExp = MaxExperienceLevel[stat.Level - 1]; //List 활용 
                }
                else
                {
                    nextLevelExp = MaxExperienceLevel[MaxExperienceLevel.Count - 1];// List에 있는 메모리보다 클때
                    int extraLevel = stat.Level - MaxExperienceLevel.Count + 1 ; // 현재 레벨에서 list 메모리만큼 차감
                    for (int i =0 ;  i < extraLevel; i++)
                    {
                        nextLevelExp *= 1.05;
                    }
                }
                if (stat.exp < nextLevelExp)
                {
                    break;
                }

                stat.exp -= nextLevelExp;
                stat.Level += 1;
                stat.BaseDefense += 1.0;
                stat.BaseAttack += 0.5;



                Console.WriteLine("============== Level Up ==============\n");
                Console.WriteLine($"축하합니다 레벨업하셨습니다!");
                Console.WriteLine($"Lv. {stat.Level - 1} {CharName.Name} -> Lv. {stat.Level} {CharName.Name}");
                Console.WriteLine("기본공격력 0.5 방어력 1이 증가하셨습니다\n");
                Console.WriteLine("\n");


              
                
            }






        }
    }
}