using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Program;

namespace TextRPG_Team3.Scenes
{
    internal class StatScene : BaseScene
    {
        public StatScene()
        {
            MenuMin = 0;
            MenuMax = 0;
        }
        public override void Render()
        {
            base.Render();

            Console.WriteLine("0. 나가기");
        }

        public override void SelectMenu(int num)
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
