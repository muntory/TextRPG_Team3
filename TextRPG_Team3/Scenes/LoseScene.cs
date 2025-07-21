using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Character;
using TextRPG_Team3.Managers;
using TextRPG_Team3.Scenes;
using TextRPG_Team3.Utils;
using static Enums;

namespace TextRPG_Team3.Scenes
{
    internal class LoseScene : BaseScene
    {
      
        public override void Render()
        {
            base.Render();
            Console.WriteLine("\n============== Battle Result ==============\n");
            RenderHelper.WriteLine($"             [   GAME OVER   ]           \n", ConsoleColor.Red);
            RenderHelper.WriteLine($"패배! 당신의 HP가 0이 되어 전투에서 졌습니다.", ConsoleColor.Red);
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"플레이어: {GameManager.Instance.Player.Name}");
            Console.WriteLine($"레벨: {GameManager.Instance.Player.Stat.Level}");
            RenderHelper.WriteLine($"HP: 0 / {GameManager.Instance.Player.Stat.MaxHealth}", ConsoleColor.DarkGray);
            RenderHelper.Write($"보유 골드: ");
            RenderHelper.WriteLine($"{GameManager.Instance.Player.Gold} G", ConsoleColor.DarkYellow);
            Console.WriteLine("------------------------------------------\n");
            Console.WriteLine("0. 타이틀로 돌아가기");
            Console.WriteLine("==========================================");
        }

        //RenderHelper.WriteLine($"HP {player.Stat.Health}/{player.Stat.MaxHealth}", ConsoleColor.Red);


        public override void SelectMenu(int input)
        {
            Enums.LoseScene loseScene = (Enums.LoseScene)input;

            switch (loseScene)
            {
                case Enums.LoseScene.Next:
                    GameManager.Instance.Player.IsAlive = true;
                    SceneManager.Instance.CurrentScene = new IntroScene();
                    break;
                default:
                    msg = "잘못된 입력입니다.";
                    break;


                    
            }
        }
    }
}
