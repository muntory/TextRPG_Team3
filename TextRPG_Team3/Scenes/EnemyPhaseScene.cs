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

            RenderHelper.WriteLine("Battle!!",ConsoleColor.DarkYellow);
            Console.WriteLine();

            PlayerCharacter target = GameManager.Instance.Player;
            EnemyCharacter attacker = currentEnemies[index];

            RenderHelper.WriteLine($"{attacker.Name} 의 공격!", ConsoleColor.DarkGreen);

            int prevHealth = target.Stat.Health;
            attacker.Attack(target);

            RenderHelper.Write($"Lv.{target.Stat.Level}", RenderHelper.GetStatColor(Enums.StatType.Level));
            RenderHelper.Write($" {target.Name}",RenderHelper.GetPlayerColor());
            RenderHelper.Write(" 을(를) 맞췄습니다.", ConsoleColor.White);
            RenderHelper.WriteLine($"[데미지 : {-(target.Stat.Health - prevHealth)}]", RenderHelper.GetStatColor(Enums.StatType.Health));
            Console.WriteLine();

            RenderHelper.Write($"Lv.{target.Stat.Level}", RenderHelper.GetStatColor(Enums.StatType.Level));
            RenderHelper.WriteLine($" {target.Name}", RenderHelper.GetPlayerColor());
            RenderHelper.Write($"HP {prevHealth} -> ", ConsoleColor.White);
            RenderHelper.Write($"{(target.IsAlive ? $"{target.Stat.Health}" : "Dead")}", (target.IsAlive ? RenderHelper.GetStatColor(Enums.StatType.Health) : ConsoleColor.DarkGray));
            Console.WriteLine();

            RenderHelper.WriteLine("0. 다음", ConsoleColor.White);
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
                SpawnManager.Instance.CurrentEnemies = null;
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
