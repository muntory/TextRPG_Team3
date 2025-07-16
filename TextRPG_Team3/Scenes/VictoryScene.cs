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
    internal class VictoryScene : BaseScene
    {
        public override void Render()
        {
            base.Render();
            Console.WriteLine("============== Battle Result ==============");
            Console.WriteLine("                 [  VICTORY  ]            \n");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"플레이어: {GameManager.Instance.Player.Name}");
            Console.WriteLine($"레벨: {GameManager.Instance.Player.Stat.Level}");
            Console.WriteLine($"HP: {GameManager.Instance.Player.Stat.Health} / {GameManager.Instance.Player.Stat.MaxHealth}");
            Console.WriteLine($"보유 골드: {GameManager.Instance.Player.Gold} G");
            Console.WriteLine("------------------------------------------\n");
            Console.WriteLine("0. 다음");
            Console.WriteLine("==========================================");
        }

        public override void SelectMenu(int input)
        {
            Enums.VictoryScene victoryScene = (Enums.VictoryScene)input;

            switch (victoryScene)
            {
                case Enums.VictoryScene.Next:
                    SceneManager.Instance.CurrentScene = new IntroScene();
                    break;
                default:
                    msg = "잘못된 입력입니다.";
                    break;
            }
        }
    
    }
}
