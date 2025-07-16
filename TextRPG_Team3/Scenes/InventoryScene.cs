using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Managers;

namespace TextRPG_Team3.Scenes
{
    internal class InventoryScene : BaseScene
    {
        public override void Render()
        {
            base.Render();
            Console.WriteLine("인벤토리");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("[아이템 목록]");
            Console.WriteLine();



        }

        public override void SelectMenu(int input)
        {
            Enums.InventoryMenu selectedNumber = (Enums.InventoryMenu)input;

            switch (selectedNumber)
            {
                case Enums.InventoryMenu.Back:
                    SceneManager.Instance.CurrentScene = new IntroScene();
                    break;
                case Enums.InventoryMenu.Set :
                    SceneManager.Instance.CurrentScene = new ItemEquipScene();
                    break;
            }
        }
    }
}
