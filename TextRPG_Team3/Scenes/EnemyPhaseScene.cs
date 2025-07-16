using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Character;
using TextRPG_Team3.Managers;

namespace TextRPG_Team3.Scenes
{
    internal class EnemyPhaseScene : BaseScene
    {
        List<EnemyCharacter> currentEnemies;
        int index = 0;
        public override void Render()
        {
            SkipEnemy();
            base.Render();
            Console.WriteLine("Battle!!\n");
            int prevHealth = GameManager.Instance.Player.PlayerStat.Health;
            currentEnemies[index].Attack(GameManager.Instance.Player);
            int followingHealth = GameManager.Instance.Player.PlayerStat.Health;
            Console.WriteLine($"Lv.{currentEnemies[index].CharacterStat.Level} {currentEnemies[index].Name}의 공격!");
            Console.WriteLine($"{GameManager.Instance.Player.Name} 을(를) 맞췄습니다. [데미지 : {prevHealth - followingHealth}]\n");

            Console.WriteLine($"Lv. {GameManager.Instance.Player.PlayerStat.Level} {GameManager.Instance.Player.Name}");
            Console.WriteLine($"HP {prevHealth} -> {followingHealth}");
            Console.WriteLine("\n0. 다음");
            SkipEnemy();
            index++;
        }
        private void SkipEnemy()
        {
            while (currentEnemies.Count>index)
            {
                if (!currentEnemies[index].IsAlive)
                {
                    index++;
                }
                else
                {
                    break;
                }
            }
        }
        public override void SelectMenu(int input)
        {
            Enums.EnemyPhaseMenuE enemyPhaseMenuE = (Enums.EnemyPhaseMenuE)input;

            switch (enemyPhaseMenuE)
            {
                case Enums.EnemyPhaseMenuE.Next:
                    if (index >= currentEnemies.Count)
                    {
                        SceneManager.Instance.CurrentScene = new BattleIntroScene(currentEnemies);
                    }
                    else
                    {

                        SceneManager.Instance.CurrentScene = this;
                    }
                        break;
                default:
                    msg = "잘못된 입력입니다.";
                    break;
            }
        }
        public EnemyPhaseScene(List<EnemyCharacter> list)
        {
            currentEnemies = list;
        }
    }
}
