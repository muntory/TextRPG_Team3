using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team3.Scenes
{
    internal class PotionScene : BaseScene
    {
        public override void Render()
        {
            base.Render();

            Console.WriteLine("회복");

        }

        public override void SelectMenu(int input)
        {
            base.SelectMenu(input);
        }
    }
}
