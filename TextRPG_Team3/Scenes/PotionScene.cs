using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Character;
using TextRPG_Team3.Managers;
using TextRPG_Team3.Utils;

namespace TextRPG_Team3.Scenes
{
    internal class PotionScene : BaseScene
    {
        ItemData potionData = ItemManager.Instance.GetItemData(100);

        public override void Render()
        {
            base.Render();

            RenderHelper.WriteLine("회복", ConsoleColor.DarkYellow);

            int potionCount = ItemManager.Instance.GetItemCount(100);

            RenderHelper.WriteLine("포션을 사용하면 체력을 30 회복할 수 있습니다.",ConsoleColor.White);
            RenderHelper.WriteLine($"(남은 포션 : {potionCount})",ConsoleColor.White);
            Console.WriteLine();

            RenderHelper.WriteLine("1. 사용하기", ConsoleColor.White);
            RenderHelper.WriteLine("0. 나가기", ConsoleColor.White);
            Console.WriteLine();

            PrintMsg();
        }

        public override void SelectMenu(int input)
        {
            Enums.PotionSceneMenu potionSceneMenu = (Enums.PotionSceneMenu)input;

            switch(potionSceneMenu)
            {
                case Enums.PotionSceneMenu.use:
                    if(ItemManager.Instance.UsePotion(100))
                    {
                        GameManager.Instance.Player.Stat.Health += potionData.Value;
                        msg = "회복이 완료되었습니다.";
                    }
                    else
                    {
                        msg = "포션이 부족합니다.";
                    }
                    break;
                case Enums.PotionSceneMenu.Back:
                    SceneManager.Instance.CurrentScene = new EnemyPhaseScene();
                    break;
            }
        }
    }
}
