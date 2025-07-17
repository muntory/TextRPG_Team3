using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Managers;

namespace TextRPG_Team3.Scenes
{
    internal class PotionScene : BaseScene
    {
        public override void Render()
        {
            base.Render();

            Console.WriteLine("회복");

            int potionCount = ItemManager.Instance.GetItemCount(100);

            Console.WriteLine("포션을 사용하면 체력을 30 회복할 수 있습니다.");
            Console.WriteLine($"(남은 포션 : {potionCount})");
            Console.WriteLine();

            Console.WriteLine("1. 사용하기");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
        }

        public override void SelectMenu(int input)
        {
            base.SelectMenu(input);
        }
    }
}
