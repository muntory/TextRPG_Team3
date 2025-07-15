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
        public void GetEnemyDB()
        {

        }

        public override void Render()
        {
            base.Render();
            Console.WriteLine("Battle!!\n");
            int prevHealth = GameManager.Instance.Player.CharacterStat.Health;
            /*
            foreach(EnemyData enemy in EnemyDB){
            Console.WriteLine($"Lv.{enemy.Level} {enemy.Name}의 공격!");
            Console.WriteLine($"{GameManager.Instance.Player.Name} 을(를) 맞췄습니다. [데미지 : ?]\n");

            Console.WriteLine($"Lv. {GameManager.Instance.Player.CharacterStat.Level} {GameManager.instance.Player.Name}");
            Console.WriteLine($"HP {prevHealth} -> {GameManager.Instance.Player.CharacterStat.Health}");

            Console.WriteLine("0. 다음");
            }
            */
        }

        public override void SelectMenu(int input)
        {
            Enums.EnemyPhaseMenuE enemyPhaseMenuE = (Enums.EnemyPhaseMenuE)input;

            switch (enemyPhaseMenuE)
            {
                case Enums.EnemyPhaseMenuE.Next:
                    SceneManager.Instance.CurrentScene = new StatScene();
                    break;
                default:
                    msg = "잘못된 입력입니다.";
                    break;
            }
        }
    }
}
