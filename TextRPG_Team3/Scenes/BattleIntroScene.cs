using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Character;
using TextRPG_Team3.Data;
using TextRPG_Team3.Managers;
using TextRPG_Team3.Stat;
using TextRPG_Team3.Utils;

namespace TextRPG_Team3.Scenes
{
    internal class BattleIntroScene : BaseScene
    {
        public override void Render()
        {
            base.Render();

            PlayerCharacter player = GameManager.Instance.Player;

            Console.WriteLine("Battle!!");
            Console.WriteLine();

            List<EnemyCharacter> currentEnemies = SpawnManager.Instance.CurrentEnemies;
            PlayerStatComponent playerStat = GameManager.Instance.Player.Stat as PlayerStatComponent;
            // List 반복문 넣어서 적 정보 갱신하기
            foreach (var enemy in currentEnemies)
            {
                WriteLineEnemyInfo(enemy);
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("[내 정보]");
            Console.WriteLine($"Lv. {player.Stat.Level} {player.Name}");
            Console.WriteLine($"HP {player.Stat.Health}/{player.Stat.MaxHealth}");
            Console.WriteLine();
            
            Console.WriteLine("1. 공격");
            Console.WriteLine("2. 스킬");
            Console.WriteLine();
        }

        public override void SelectMenu(int input)
        {
            Enums.BattleMenu selectedNumber = (Enums.BattleMenu)input;

            switch (selectedNumber)
            {
                case Enums.BattleMenu.Attack:
                    SceneManager.Instance.PreviousScene = SceneManager.Instance.CurrentScene;
                    SceneManager.Instance.CurrentScene = new PlayerPhaseScene();
                    break;
                case Enums.BattleMenu.Skill:
                    SceneManager.Instance.CurrentScene = new SkillSelectScene();
                    break;
                default:
                    msg = "잘못된 입력입니다.";
                    break;
            }
        }
        private void WriteLineEnemyInfo(EnemyCharacter enemy)
        {
            string str = $"LV.{enemy.Stat.Level} {RenderHelper.PadLeftToWidth(enemy.Name, 14)} {(enemy.IsAlive ? $"HP {enemy.Stat.Health}" : "Dead")}";

            if (enemy.IsAlive)
            {
                Console.WriteLine(str);

            }
            else
            {
                RenderHelper.WriteLine(str, ConsoleColor.DarkGray);
            }

        }

        public BattleIntroScene()
        {
            SpawnManager.Instance.SpawnRandomEnemies();
        }

    }
}
