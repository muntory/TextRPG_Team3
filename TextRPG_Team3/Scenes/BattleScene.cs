using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Managers;

namespace TextRPG_Team3.Scenes
{
    internal class BattleScene : BaseScene
    {
        public override void Render()
        {
            base.Render();

            Console.WriteLine("이 곳은 BattleScene입니다.");
            Console.WriteLine();

            Console.WriteLine("0. 나가기");
            Console.WriteLine();

        }

        public override void SelectMenu(int input)
        {
            Enums.BattleMenu selectedNumber = (Enums.BattleMenu)input;

            switch (selectedNumber)
            {
                case Enums.BattleMenu.Out:
                    SceneManager.Instance.CurrentScene = new IntroScene();
                    break;
                default:
                    break;
            }
        }
    }
}
