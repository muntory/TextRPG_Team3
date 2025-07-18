using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team3.Scenes
{
    internal class ItemEquipScene : BaseScene
    {
        public override void Render()
        {
            base.Render();

            Console.WriteLine("인벤토리 - 장착관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            

        }

        public override void SelectMenu(int input)
        {
            base.SelectMenu(input);
        }
    }
}
