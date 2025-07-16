using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Character;
using TextRPG_Team3.Data;
using TextRPG_Team3.Managers;
using TextRPG_Team3.Utils;
using TextRPG_Team3.Stat;

namespace TextRPG_Team3.Scenes
{
    public class AttackResultScene : BaseScene
    {
        SkillData skillData;
        public AttackResultScene(SkillData skillData = null)
        {
            this.skillData = skillData;
        }
        public override void Render()
        {
            base.Render();

            List<EnemyCharacter> currentEnemies = SpawnManager.Instance.CurrentEnemies;

            Console.WriteLine("Battle!!");
            Console.WriteLine();

            PlayerCharacter player = GameManager.Instance.Player;
            EnemyCharacter target;

            if (skillData == null)
            {
                target = currentEnemies[InputManager.Instance.UserInput - 1];
                Console.WriteLine($"{player.Name} 의 공격!");

                int prevHealth = target.Stat.Health;

                int result = player.Attack(target);

                if (result >= 0)
                {
                    Console.WriteLine($"Lv.{target.Stat.Level} {target.Name} 을(를) 맞췄습니다. [데미지 : {-(target.Stat.Health - prevHealth)}] {(result == 1 ? "- 치명타 공격!!" : "")}");
                    Console.WriteLine();

                    Console.WriteLine($"Lv.{target.Stat.Level} {target.Name}");
                    Console.WriteLine($"HP {prevHealth} -> {(target.IsAlive ? $"{target.Stat.Health}" : "Dead")}");
                    Console.WriteLine();
                }
                else if (result == -1)
                {
                    Console.WriteLine($"Lv.{target.Stat.Level} {target.Name} 을(를) 공격했지만 아무일도 일어나지 않았습니다.");
                    Console.WriteLine();
                }
            }
            else
            {
                
                (player.Stat as PlayerStatComponent).MP -= skillData.CostValue;

                for (int i = 0; i < skillData.TargetCount; ++i)
                {
                    Console.Clear();

                    Console.WriteLine($"{player.Name} 의 {skillData.SkillName}!");
                    int targetIndex;
                    if (skillData.RandomAttack)
                    {
                        do
                        {
                            targetIndex = Random.Shared.Next(currentEnemies.Count);
                        } 
                        while (!currentEnemies[targetIndex].IsAlive);

                    }
                    else
                    {
                        targetIndex = InputManager.Instance.UserInput - 1;
                    }

                    target = currentEnemies[targetIndex];
                    int prevHealth = target.Stat.Health;

                    
                    player.ActiveSkill(target, skillData);

                    Console.WriteLine($"Lv.{target.Stat.Level} {target.Name} 을(를) 맞췄습니다. [데미지 : {-(target.Stat.Health - prevHealth)}]");
                    Console.WriteLine();

                    Console.WriteLine($"Lv.{target.Stat.Level} {target.Name}");
                    Console.WriteLine($"HP {prevHealth} -> {(target.IsAlive ? $"{target.Stat.Health}" : "Dead")}");
                    Console.WriteLine();

                    Thread.Sleep(1000);

                }
            }

            


            Console.WriteLine("0. 다음");
            Console.WriteLine();

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
            
            if (SpawnManager.Instance.HasEnemies())
            {
                SceneManager.Instance.CurrentScene = new EnemyPhaseScene();
            }
            else
            {
                SceneManager.Instance.CurrentScene = new VictoryScene();
            }
            
            

        }
    }
}
