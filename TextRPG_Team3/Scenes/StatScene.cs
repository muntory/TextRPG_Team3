using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Interfaces;
using static Program;

namespace TextRPG_Team3.Scenes
{
    internal class StatScene : IScene
    {
        public void Render(ref int menuMin, ref int menuMax)
        {
            menuMin = 0; menuMax = 0;
            Console.WriteLine("이 곳은 스탯 씬입니다.\n");

            Console.WriteLine("0. 나가기");
        }

        public void SelectMenu(int num)
        {
            StatMenuE selectedNumber = new StatMenuE();

            selectedNumber = (StatMenuE)num;

            switch (selectedNumber)
            {
                case StatMenuE.Out:
                    SceneManager.Instance.CurrentScene = new IntroScene(); break;
            }
        }
    }
}
