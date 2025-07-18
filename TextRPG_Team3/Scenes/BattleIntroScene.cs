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

            RenderHelper.WriteLine("Battle!!",ConsoleColor.DarkYellow);
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

            RenderHelper.WriteLine("[내 정보]",ConsoleColor.White);
            RenderHelper.WriteLine($"Lv. {player.Stat.Level} {player.Name}",ConsoleColor.White);
            RenderHelper.WriteLine($"HP {player.Stat.Health}/{player.Stat.MaxHealth}", ConsoleColor.Red);
            Console.WriteLine();
            
            RenderHelper.WriteLine("1. 공격", ConsoleColor.Yellow);
            RenderHelper.WriteLine("2. 스킬", ConsoleColor.Cyan);
            RenderHelper.WriteLine("3. 아이템", ConsoleColor.White);

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
                case Enums.BattleMenu.Item:
                    SceneManager.Instance.PreviousScene = SceneManager.Instance.CurrentScene;
                    SceneManager.Instance.CurrentScene = new PotionScene();
                    break;
                default:
                    msg = "잘못된 입력입니다.";
                    break;
            }
        }
        private void WriteLineEnemyInfo(EnemyCharacter enemy)
        {

            string str = $"LV.{enemy.Stat.Level} {RenderHelper.AlignLeftWithPadding(enemy.Name, 14)} {(enemy.IsAlive ? $"HP {enemy.Stat.Health}" : "Dead")}";

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
            SpawnManager.Instance.GenerateStage(GameManager.CurrentStage);
        }

    }
}
