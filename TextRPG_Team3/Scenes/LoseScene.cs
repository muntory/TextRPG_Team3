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
using static Enums;

namespace TextRPG_Team3.Scenes
{
    internal class LoseScene : BaseScene
    {
        public void CheckPlayerLose()
        {
            if (GameManager.Instance.Player.PlayerStat.Health == 0)
            {
                LoseScene loseScene = new LoseScene();
                Render();
            }
        }


        public override void Render()
        {
            base.Render();
            Console.WriteLine("============== Battle Result ==============");
            Console.WriteLine("               [   GAME OVER   ]           \n");
            Console.WriteLine("패배! 당신의 HP가 0이 되어 전투에서 졌습니다.");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"플레이어: {GameManager.Instance.Player.Name}");
            Console.WriteLine($"레벨: {GameManager.Instance.Player.PlayerStat.Level}");
            Console.WriteLine($"HP: 0 / {GameManager.Instance.Player.PlayerStat.MaxHealth}");
            Console.WriteLine($"보유 골드: {GameManager.Instance.Player.Gold} G");
            Console.WriteLine("------------------------------------------\n");
            Console.WriteLine("0. 타이틀로 돌아가기");
            Console.WriteLine("==========================================");
        }

        public override void SelectMenu(int input)
        {
            Enums.LoseScene loseScene = (Enums.LoseScene)input;

            switch (loseScene)
            {
                case Enums.LoseScene.Next:
                    SceneManager.Instance.CurrentScene = new IntroScene();
                    break;
                default:
                    msg = "잘못된 입력입니다.";
                    break;
            }
        }
    }
}
