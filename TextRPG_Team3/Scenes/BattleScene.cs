using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Interfaces;
using TextRPG_Team3.Managers;
using static Program;

namespace TextRPG_Team3.Scenes
{
    internal class BattleScene : BaseScene
    {
        public BattleScene()
        {
            MenuMin = 0;
            MenuMax = 0;
        }

        public override void Render()
        {
            base.Render();
            Console.WriteLine("이 곳은 BattleScene입니다.\n");

            Console.WriteLine("0. 나가기");
        }

        public override void SelectMenu(int num)
        {
            BattleMenuE selectedNumber = new BattleMenuE();

            selectedNumber = (BattleMenuE)num;

            switch (selectedNumber)
            {
                case BattleMenuE.Out:
                    SceneManager.Instance.CurrentScene = new IntroScene(); break;
            }
        }
    }
}
