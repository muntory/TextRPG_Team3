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
using System.ComponentModel.Design;

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

            RenderHelper.WriteLine("Battle!!", ConsoleColor.DarkYellow);
            Console.WriteLine();

            PlayerCharacter player = GameManager.Instance.Player;
            PlayerStatComponent playerStat = player.Stat as PlayerStatComponent;
            EnemyCharacter target;

            if (skillData == null)
            {
                int targetIndex = GetTargetIndex();
                target = currentEnemies[targetIndex];

                RenderNormalAttack(player, target);
            }
            else // 스킬공격
            {
                playerStat.MP -= skillData.CostValue;

                if (!skillData.IsTargetAll)
                {
                    for (int i = 0; i < skillData.TargetCount; ++i)
                    {
                        if (!SpawnManager.Instance.HasEnemies())
                        {
                            break;
                        }

                        int targetIndex = GetTargetIndex();
                        target = currentEnemies[targetIndex];

                        RenderSkill(player, target);
                    }

                }
                else
                {
                    foreach (EnemyCharacter enemy in currentEnemies)
                    {
                        if (!enemy.IsAlive) continue;

                        RenderSkill(player, enemy);

                    }
                }
            }
            
            Console.WriteLine("0. 다음");
            Console.WriteLine();

        }

        private int GetTargetIndex()
        {
            int targetIndex = 0;
            List<EnemyCharacter> currentEnemies = SpawnManager.Instance.CurrentEnemies;

            if (skillData == null || !skillData.RandomAttack)
            {
                targetIndex = InputManager.Instance.UserInput - 1;

            }
            else
            {
                do
                {
                    targetIndex = Random.Shared.Next(currentEnemies.Count);
                }
                while (!currentEnemies[targetIndex].IsAlive);
            }

            return targetIndex;
        }

        private void RenderNormalAttack(PlayerCharacter player, EnemyCharacter target)
        {
            Console.WriteLine($"{player.Name} 의 공격!");

            int prevHealth = target.Stat.Health;
            int result = player.Attack(target);

            if (result >= 0)
            {
                Console.Write($"Lv.{target.Stat.Level} {target.Name} 을(를) 맞췄습니다. ");

                if (result == 1)
                {
                    RenderHelper.WriteLine($"[데미지 : {(prevHealth - target.Stat.Health)}] - 치명타 공격!!", ConsoleColor.DarkRed);
                }
                else
                {
                    RenderHelper.WriteLine($"[데미지 : {(prevHealth - target.Stat.Health)}]");
                }
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

        private void RenderSkill(PlayerCharacter player, EnemyCharacter target)
        {
            int prevHealth = target.Stat.Health;

            int result = player.ActiveSkill(target, skillData);

            Console.Clear();

            Console.WriteLine($"{player.Name} 의 {skillData.SkillName}!");
            Console.Write($"Lv.{target.Stat.Level} {target.Name} 을(를) 맞췄습니다. ");
            if (result == 1)
            {
                RenderHelper.WriteLine($"[데미지 : {(prevHealth - target.Stat.Health)}] - 치명타 공격!!", ConsoleColor.DarkRed);
            }
            else
            {
                RenderHelper.WriteLine($"[데미지 : {(prevHealth - target.Stat.Health)}]");
            }
            Console.WriteLine();

            Console.WriteLine($"Lv.{target.Stat.Level} {target.Name}");
            Console.WriteLine($"HP {prevHealth} -> {(target.IsAlive ? $"{target.Stat.Health}" : "Dead")}");
            Console.WriteLine();

            Thread.Sleep(1000);
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
