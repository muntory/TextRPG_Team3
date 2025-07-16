using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Character;
using TextRPG_Team3.Managers;
using TextRPG_Team3.Utils;

namespace TextRPG_Team3.Scenes
{
    internal class EnemyPhaseScene : BaseScene
    {
        int index = FindNextIndex(-1);
        List<EnemyCharacter> currentEnemies = SpawnManager.Instance.CurrentEnemies;
        public override void Render()
        {
            base.Render();

            Console.WriteLine("Battle!!");
            Console.WriteLine();

            PlayerCharacter target = GameManager.Instance.Player;
            EnemyCharacter attacker = currentEnemies[index];

            Console.WriteLine($"{attacker.Name} 의 공격!");

            int prevHealth = target.Stat.Health;
            attacker.Attack(target);

            Console.WriteLine($"Lv.{target.Stat.Level} {target.Name} 을(를) 맞췄습니다. [데미지 : {-(target.Stat.Health - prevHealth)}]");
            Console.WriteLine();

            Console.WriteLine($"Lv.{target.Stat.Level} {target.Name}");
            Console.WriteLine($"HP {prevHealth} -> {(target.IsAlive ? $"{target.Stat.Health}" : "Dead")}");
            Console.WriteLine();

            Console.WriteLine("0. 다음");
            Console.WriteLine();
        }

        private static int FindNextIndex(int index)
        {
            do
            {
                index++;
            }
            while (index < SpawnManager.Instance.CurrentEnemies.Count && !SpawnManager.Instance.CurrentEnemies[index].IsAlive);

            return index;
        }

        private void SkipEnemy()
        {
            List<EnemyCharacter> currentEnemies = SpawnManager.Instance.CurrentEnemies;

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
            if (input != 0)
            {
                do
                {
                    RenderHelper.DeleteConsoleLine(2);

                }
                while (InputManager.Instance.GetPlayerInput() != 0);
            }

            if (!GameManager.Instance.Player.IsAlive)
            {
                SceneManager.Instance.CurrentScene = new LoseScene();
                return;
            }

            index = FindNextIndex(index);
            if (index >= currentEnemies.Count)
            {
                SceneManager.Instance.CurrentScene = new BattleIntroScene();
                return;
            }
            Enums.EnemyPhaseMenuE enemyPhaseMenu = (Enums.EnemyPhaseMenuE)input;

            switch(enemyPhaseMenu)
            {
                case Enums.EnemyPhaseMenuE.Next:
                    break;
                default:
                    msg = "잘못된 입력입니다.";
                    break;
            }
        }
        
    }
}
