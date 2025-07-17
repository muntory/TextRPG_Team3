using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Character;
using TextRPG_Team3.Managers;

namespace TextRPG_Team3.Scenes
{
    internal class IntroScene : BaseScene
    {
        public override void Render()
        {
            base.Render();

            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("이제 전투를 시작할 수 있습니다.");
            Console.WriteLine();

            Console.WriteLine("1. 상태 보기");
            Console.WriteLine($"2. 전투 시작 (현재 진행 : {GameManager.CurrentStage}층)");
            Console.WriteLine("3. 퀘스트");
            Console.WriteLine();

            PrintMsg();
        }


        public override void SelectMenu(int input)
        {
            Enums.IntroMenu introMenuE = (Enums.IntroMenu)input;

            switch (introMenuE)
            {
                case Enums.IntroMenu.Stat:
                    SceneManager.Instance.CurrentScene = new StatScene();
                    break;
                case Enums.IntroMenu.Battle:
                    SceneManager.Instance.LoadScene(new BattleIntroScene());
                    break;
                case Enums.IntroMenu.Quest:
                    SceneManager.Instance.CurrentScene = new QuestScene();
                    break;
                default:
                    msg = "잘못된 입력입니다.";
                    break;
            }
        }
    }
}
