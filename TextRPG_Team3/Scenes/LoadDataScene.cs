using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Managers;
using TextRPG_Team3.Utils;

namespace TextRPG_Team3.Scenes
{
    public class LoadDataScene:BaseScene
    {
        public override void Render()
        {
            base.Render();
            RenderHelper.WriteLine("데이터 불러오기", ConsoleColor.DarkYellow);
            RenderHelper.WriteLine("세이브 데이터가 감지되었습니다.", ConsoleColor.White);
            Console.WriteLine();
            RenderHelper.WriteLine("새로하기를 누르면 데이터를 받아오지 않고 이름/직업 선택으로 넘어갑니다.", ConsoleColor.White);
            RenderHelper.WriteLine("불러오기를 누르면 데이터를 받아와 메인 메뉴로 가게 됩니다.", ConsoleColor.White);
            RenderHelper.WriteLine("새로할 시 저장을 누르면 이전의 데이터는 덮어쓰게 되니 주의해주세요!", ConsoleColor.White);
            Console.WriteLine();
            RenderHelper.WriteLine("1. 새로하기", ConsoleColor.White);
            RenderHelper.WriteLine("2. 불러오기", ConsoleColor.White);
            Console.WriteLine();
            PrintMsg();
        }


        public override void SelectMenu(int input)
        {
            Enums.LoadMenu loadMenu = (Enums.LoadMenu)input;

            switch (loadMenu)
            {
                case Enums.LoadMenu.New:
                    SceneManager.Instance.CurrentScene = new ChooseScene();
                    break;
                case Enums.LoadMenu.Load:
                    SaveAndLoad load = new();
                    load.Load();
                    SceneManager.Instance.CurrentScene = new IntroScene();
                    break;
                default:
                    msg = "잘못된 입력입니다.";
                    break;
            }
        }
    }
}
