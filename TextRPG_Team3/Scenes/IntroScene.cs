using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Character;
using TextRPG_Team3.Managers;
using TextRPG_Team3.Utils;

namespace TextRPG_Team3.Scenes
{
    internal class IntroScene : BaseScene
    {
        public override void Render()
        {
            base.Render();

            RenderHelper.Write("스파르타 던전",ConsoleColor.DarkYellow);
            RenderHelper.WriteLine("에 오신 여러분 환영합니다.", ConsoleColor.White);
            RenderHelper.WriteLine("이제 전투를 시작할 수 있습니다.", ConsoleColor.White);
            Console.WriteLine();

            RenderHelper.WriteLine("1. 상태 보기", ConsoleColor.White);
            RenderHelper.WriteLine($"2. 전투 시작 (현재 진행 : {GameManager.CurrentStage}층)", ConsoleColor.White);
            RenderHelper.WriteLine("3. 퀘스트", ConsoleColor.White);
            RenderHelper.WriteLine("4. 포켓몬 센터",ConsoleColor.White);
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
                    SceneManager.Instance.CurrentScene = new BattleIntroScene();
                    break;
                case Enums.IntroMenu.Quest:
                    SceneManager.Instance.CurrentScene = new QuestScene();
                    break;
                case Enums.IntroMenu.Potion:
                    SceneManager.Instance.CurrentScene = new PokemonCenterScene();
                    break;
                case Enums.IntroMenu.RefineBadge:
                    SceneManager.Instance.CurrentScene = new BadgeRefineScene();
                    break;
                default:
                    msg = "잘못된 입력입니다.";
                    break;
            }
        }
    }
}
