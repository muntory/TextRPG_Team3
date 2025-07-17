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

            Console.WriteLine("[내정보]");
            Console.WriteLine($"LV.{playerStat.Level} {player.Name}");
            Console.WriteLine($"HP {playerStat.Health}/{playerStat.MaxHealth}");
            Console.WriteLine($"MP {playerStat.MP}/{playerStat.MaxMP}");

            Console.WriteLine();

            int index = 1;
            foreach (SkillData skillData in player.SkillList)
            {
                Console.WriteLine($"{index}. {skillData.SkillName} - MP {skillData.CostValue}");
                if (skillData.RandomAttack)
                {
                    Console.WriteLine($"공격력 * {skillData.Multiplier} 로 {skillData.TargetCount}명의 적을 랜덤으로 공격합니다.");
                }
                else
                {
                    Console.WriteLine($"공격력 * {skillData.Multiplier} 로 적을 {skillData.TargetCount}번 공격합니다.");

                }
                index++;
            }
            Console.WriteLine();

            Console.WriteLine("0. 취소");
            Console.WriteLine();

            PrintMsg();
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
