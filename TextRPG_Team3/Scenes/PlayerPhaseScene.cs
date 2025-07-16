using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Character;
using TextRPG_Team3.Managers;
using TextRPG_Team3.Utils;
using TextRPG_Team3.Scenes;

namespace TextRPG_Team3.Scenes
{
    public class PlayerPhaseScene : BaseScene
    {
        bool isAttacked = false;
        List<EnemyCharacter> currentEnemies;
        public override void Render()
        {
            base.Render();
            PlayerCharacter player = GameManager.Instance.Player;

            if (!isAttacked)
            {
                Console.WriteLine("Battle!!");
                Console.WriteLine();

                for (int i = 0; i < currentEnemies.Count; ++i)
                {
                    EnemyCharacter enemy = currentEnemies[i];
                    Console.WriteLine($"{i + 1} LV.{enemy.CharacterStat.Level} {RenderHelper.PadLeftToWidth(enemy.Name, 14)} {(enemy.IsAlive ? $"HP {enemy.CharacterStat.Health}" : "Dead")}");

                }

                Console.WriteLine("[내정보]");
                Console.WriteLine($"LV.{player.PlayerStat.Level} {player.Name}");
                Console.WriteLine($"HP {player.PlayerStat.MaxHealth}/{player.PlayerStat.Health}");
                Console.WriteLine();

                Console.WriteLine("0. 취소");
            }
            else
            {
                Console.WriteLine("Battle!!");
                Console.WriteLine();

                EnemyCharacter target = currentEnemies[InputManager.Instance.UserInput - 1];
                Console.WriteLine($"{player.Name} 의 공격!");

                int prevHealth = target.CharacterStat.Health;
                player.Attack(target);

                Console.WriteLine($"Lv.{target.CharacterStat.Level} {target.Name} 을(를) 맞췄습니다. [데미지 : {-(target.CharacterStat.Health - prevHealth)}]");
                Console.WriteLine();

                Console.WriteLine($"Lv.{target.CharacterStat.Level} {target.Name}");
                Console.WriteLine($"HP {prevHealth} -> {(target.IsAlive ? $"{target.CharacterStat.Health}" : "Dead")}");
                Console.WriteLine();

                Console.WriteLine("0. 다음");

           

                Console.WriteLine("0. 다음");
            }
            if (GameManager.Instance.CheckVictory(currentEnemies))
            {
                GameManager.Instance.Victory = true;
            }
            PrintMsg();
        }

        public override void SelectMenu(int input)
        {
            if (0 < input && input  <= currentEnemies.Count)
            {
                if (!currentEnemies[input - 1].IsAlive)
                {
                    msg = "잘못된 입력입니다.";
                    return;
                }
                isAttacked = true;
                return;
            }

            Enums.PlayerPhaseMenu playerPhaseMenu = (Enums.PlayerPhaseMenu)input;

            switch (playerPhaseMenu)
            {
                case Enums.PlayerPhaseMenu.Out:
                    if (GameManager.Instance.CheckVictory(currentEnemies))
                    {
                        SceneManager.Instance.CurrentScene = new VictoryScene();
                        break;
                    }

                    else { if (isAttacked)
                        {
                            SceneManager.Instance.CurrentScene = new EnemyPhaseScene(currentEnemies);
                        }
                        else
                        {
                            SceneManager.Instance.CurrentScene = new BattleIntroScene(currentEnemies);
                        }
                        break;
                    }
                default:
                    msg = "잘못된 입력입니다.";
                    break;
            }
        }

        public PlayerPhaseScene(List<EnemyCharacter> enemies)
        {
            currentEnemies = enemies;
        }
    }
}
