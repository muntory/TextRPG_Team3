using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Character;
using TextRPG_Team3.Data;
using TextRPG_Team3.Managers;
using TextRPG_Team3.Stat;
using TextRPG_Team3.Utils;

namespace TextRPG_Team3.Scenes
{
    public class SkillSelectScene : BaseScene
    {

        public SkillSelectScene()
        {

        }
        public override void Render()
        {
            base.Render();

            RenderHelper.WriteLine("Battle!!", ConsoleColor.DarkYellow);
            Console.WriteLine();

            List<EnemyCharacter> currentEnemies = SpawnManager.Instance.CurrentEnemies;
            PlayerCharacter player = GameManager.Instance.Player;
            PlayerStatComponent playerStat = player.Stat as PlayerStatComponent;

            foreach (var enemy in currentEnemies)
            {
                WriteLineEnemyInfo(enemy);
            }

            Console.WriteLine();
            Console.WriteLine();

            RenderHelper.WriteLine("[내정보]",ConsoleColor.White);
            RenderHelper.WriteLine($"LV.{playerStat.Level} {player.Name}", ConsoleColor.White);
            RenderHelper.WriteLine($"HP {playerStat.Health}/{playerStat.MaxHealth}", ConsoleColor.Red);
            RenderHelper.WriteLine($"MP {playerStat.MP}/{playerStat.MaxMP}", ConsoleColor.Blue);

            Console.WriteLine();

            int index = 1;
            
            foreach (SkillData skillData in player.SkillList)
            {
                RenderHelper.WriteLine($"{index}. {skillData.SkillName} - MP {skillData.CostValue}", RenderHelper.GetPlayerColor());
                RenderHelper.WriteLine(skillData.Description, ConsoleColor.White);
                index++;
            }
            Console.WriteLine();

            RenderHelper.WriteLine("0. 취소", ConsoleColor.White);
            Console.WriteLine();

            PrintMsg();
        }

        private void WriteLineEnemyInfo(EnemyCharacter enemy)
        {
            string str = $"LV. {RenderHelper.AlignLeftWithPadding(enemy.Stat.Level.ToString(), 5)} {RenderHelper.AlignLeftWithPadding(enemy.Name, 14)} ";
            string hpstr = $"{(enemy.IsAlive ? $"HP {enemy.Stat.Health}" : "Dead")}";

            if (enemy.IsAlive)
            {
                RenderHelper.Write(str, ConsoleColor.White);
                RenderHelper.WriteLine(hpstr, ConsoleColor.Red);
            }
            else
            {
                RenderHelper.Write(str, ConsoleColor.DarkGray);
                RenderHelper.WriteLine(hpstr, ConsoleColor.DarkGray);
            }

        }

        public override void SelectMenu(int input)
        {
            if (0 < input && input <= GameManager.Instance.Player.SkillList.Count)
            {
                SkillData skillData = GameManager.Instance.Player.SkillList[InputManager.Instance.UserInput - 1];

                if (skillData.CostValue > (GameManager.Instance.Player.Stat as PlayerStatComponent)?.MP)
                {
                    msg = "MP가 부족합니다.";
                    return;
                }

                if (skillData.RandomAttack)
                {
                    SceneManager.Instance.CurrentScene = new AttackResultScene(skillData);
                }
                else
                {
                    SceneManager.Instance.PreviousScene = SceneManager.Instance.CurrentScene;
                    SceneManager.Instance.CurrentScene = new PlayerPhaseScene(skillData);
                }

                
                return;
            }

            if (input != 0)
            {
                do
                {
                    RenderHelper.DeleteConsoleLine(2);

                }
                while (InputManager.Instance.GetPlayerInput() != 0);
            }

            SceneManager.Instance.CurrentScene = new BattleIntroScene();

        }
    }
}
