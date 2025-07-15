using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Managers;
using static Program;

namespace TextRPG_Team3.Scenes
{
    internal class IntroScene : BaseScene
    {
        public IntroScene()
        {
            MenuMin = 1;
            MenuMax = 2;
        }

        public override void Render()
        {
            base.Render();
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("이제 전투를 시작할 수 있습니다.\n");

            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 전투 시작");
        }

        public override void SelectMenu(int num)
        {
            //base.SelectMenu();
            IntroMenuE introMenuE = new IntroMenuE();

            introMenuE = (IntroMenuE)num;

            switch (introMenuE)
            {
                case IntroMenuE.Stat:
                    SceneManager.Instance.CurrentScene = new StatScene();
                    ResourceManager.Instance.SaveJsonData($"{ResourceManager.GAME_ROOT_DIR}/Save/Character/Player.json", GameManager.Instance.Player);
                    break;
                case IntroMenuE.Battle:
                    SceneManager.Instance.CurrentScene = new BattleScene(); break;
            }
        }
    }
}
