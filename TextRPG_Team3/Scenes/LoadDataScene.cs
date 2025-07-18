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

            Console.WriteLine("1. 새로하기");
            Console.WriteLine("2. 불러오기");

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
