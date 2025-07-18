using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextRPG_Team3.Character;
using TextRPG_Team3.Managers;
using TextRPG_Team3.Utils;
using TextRPG_Team3.Scenes;
using TextRPG_Team3.Data;

namespace TextRPG_Team3.Scenes
{
    public class PlayerPhaseScene : BaseScene
    {
        SkillData skillData;
        public PlayerPhaseScene(SkillData skillData = null)
        {
            this.skillData = skillData;
        }

        public override void Render()
        {
            base.Render();
            PlayerCharacter player = GameManager.Instance.Player;
            List<EnemyCharacter> currentEnemies = SpawnManager.Instance.CurrentEnemies;

            RenderHelper.WriteLine($"Battle!!", ConsoleColor.DarkYellow);

            Console.WriteLine();

            for (int i = 0; i < currentEnemies.Count; ++i)
            {
                EnemyCharacter enemy = currentEnemies[i];

                WriteLineEnemyInfo(enemy, i);

            }
            Console.WriteLine();
            Console.WriteLine();

            RenderHelper.WriteLine("[내정보]",ConsoleColor.White);
            RenderHelper.WriteLine($"LV.{player.Stat.Level} {player.Name}", ConsoleColor.White);
            RenderHelper.WriteLine($"HP {player.Stat.Health}/{player.Stat.MaxHealth}", ConsoleColor.Red);
            Console.WriteLine();

            RenderHelper.WriteLine("0. 취소", ConsoleColor.White);
            Console.WriteLine();

            
            PrintMsg();
        }

        private void WriteLineEnemyInfo(EnemyCharacter enemy, int index)
        {
            string str = $"{index + 1} LV.{enemy.Stat.Level} {RenderHelper.AlignLeftWithPadding(enemy.Name, 14)} ";
            string hpstr = $"{(enemy.IsAlive ? $"HP {enemy.Stat.Health}" : "Dead")}";

            if (enemy.IsAlive)
            {
                RenderHelper.Write(str, ConsoleColor.White);
                RenderHelper.WriteLine(hpstr, ConsoleColor.Red);
            }
            else
            {
                RenderHelper.Write(str, ConsoleColor.DarkGray);
                RenderHelper.WriteLine(hpstr,ConsoleColor.Red);
            }
            
        }

        public override void SelectMenu(int input)
        {
            if (0 < input && input <= SpawnManager.Instance.CurrentEnemies.Count)
            {
                if (!SpawnManager.Instance.CurrentEnemies[input - 1].IsAlive)
                {
                    msg = "잘못된 입력입니다.";
                    return;
                }
                
                if (SceneManager.Instance.PreviousScene is SkillSelectScene)
                {
                    SceneManager.Instance.PreviousScene = SceneManager.Instance.CurrentScene;
                    SceneManager.Instance.CurrentScene = new AttackResultScene(skillData);
                }
                else
                {
                    SceneManager.Instance.CurrentScene = new AttackResultScene();
                }
                return;
            }
            

            Enums.PlayerPhaseMenu playerPhaseMenu = (Enums.PlayerPhaseMenu)input;

            switch (playerPhaseMenu)
            {
                case Enums.PlayerPhaseMenu.Out:
                    SceneManager.Instance.CurrentScene = SceneManager.Instance.PreviousScene;
                    break;
                default:
                    msg = "잘못된 입력입니다.";
                    break;
            }
        }

        
    }
}
