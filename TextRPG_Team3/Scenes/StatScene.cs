using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Managers;
using TextRPG_Team3.Utils;

namespace TextRPG_Team3.Scenes
{
    internal class StatScene : BaseScene
    {
        public override void Render()
        {
            base.Render();
            string extraAttackStr = (GameManager.Instance.Player.Stat.ExtraAttack == 0) ? "" : $" + {GameManager.Instance.Player.Stat.ExtraAttack}";
            string extraDefenseStr = (GameManager.Instance.Player.Stat.ExtraDefense == 0) ? "" : $" + {GameManager.Instance.Player.Stat.ExtraDefense}";
            RenderHelper.WriteLine("상태 보기", ConsoleColor.DarkYellow);
            RenderHelper.WriteLine("캐릭터의 정보가 표시됩니다.", ConsoleColor.White);
            Console.WriteLine();

            RenderHelper.WriteLine($"{GameManager.Instance.Player.Name} ({GameManager.Instance.Player.RootClass})", RenderHelper.GetPlayerColor());
            RenderHelper.WriteLine($"Lv. {GameManager.Instance.Player.Stat.Level}",RenderHelper.GetStatColor(Enums.StatType.Level));
            RenderHelper.Write("경험치\t:", ConsoleColor.White);
            RenderHelper.WriteLine(RenderHelper.AlignRightWithPadding($"{GameManager.Instance.Player.Stat.exp}", 7), RenderHelper.GetStatColor(Enums.StatType.Level));
            RenderHelper.Write($"공격력\t:", ConsoleColor.White);
            RenderHelper.WriteLine(RenderHelper.AlignRightWithPadding($"{GameManager.Instance.Player.Stat.BaseAttack}{extraAttackStr}", 7), RenderHelper.GetStatColor(Enums.StatType.Attack));
            RenderHelper.Write($"방어력\t:", ConsoleColor.White);
            RenderHelper.WriteLine(RenderHelper.AlignRightWithPadding($"{GameManager.Instance.Player.Stat.BaseDefense}{extraDefenseStr}", 7), RenderHelper.GetStatColor(Enums.StatType.Defense));
            RenderHelper.Write($"체력\t:", ConsoleColor.White);
            RenderHelper.WriteLine(RenderHelper.AlignRightWithPadding($"{GameManager.Instance.Player.Stat.Health}", 7), RenderHelper.GetStatColor(Enums.StatType.Health));
            RenderHelper.Write($"Gold\t:", ConsoleColor.White);
            RenderHelper.WriteLine(RenderHelper.AlignRightWithPadding($"{GameManager.Instance.Player.Gold} G", 7), ConsoleColor.DarkYellow);
            Console.WriteLine();

            RenderHelper.WriteLine("1. 인벤토리",ConsoleColor.White);
            RenderHelper.WriteLine("0. 나가기", ConsoleColor.White);
            Console.WriteLine();

            PrintMsg();
        }

        public override void SelectMenu(int input)
        {
            Enums.StatMenu selectedNumber = (Enums.StatMenu)input;

            switch (selectedNumber)
            {
                case Enums.StatMenu.Out:
                    SceneManager.Instance.CurrentScene = new IntroScene();
                    break;
                case Enums.StatMenu.Inventory:
                    SceneManager.Instance.CurrentScene = new InventoryScene();
                    break;
                default:
                    msg = "잘못된 입력입니다.";
                    break;
            }
        }
    }
}
