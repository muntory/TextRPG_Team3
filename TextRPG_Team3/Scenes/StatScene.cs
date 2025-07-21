using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Managers;
using TextRPG_Team3.Stat;
using TextRPG_Team3.Utils;

namespace TextRPG_Team3.Scenes
{
    internal class StatScene : BaseScene
    {
        public override void Render()
        {
            base.Render();
            // 최종 공격력, 방어력 수식 바뀌어서 주석처리
            // string extraAttackStr = (GameManager.Instance.Player.Stat.ExtraAttack == 0) ? "" : $" + {GameManager.Instance.Player.Stat.ExtraAttack}";
            // string extraDefenseStr = (GameManager.Instance.Player.Stat.ExtraDefense == 0) ? "" : $" + {GameManager.Instance.Player.Stat.ExtraDefense}";
            RenderHelper.WriteLine("상태 보기", ConsoleColor.DarkYellow);
            RenderHelper.WriteLine("캐릭터의 정보가 표시됩니다.", ConsoleColor.White);
            Console.WriteLine();

            PlayerStatComponent playerStat = GameManager.Instance.Player.Stat as PlayerStatComponent;

            RenderHelper.WriteLine($"{GameManager.Instance.Player.Name} ({GameManager.Instance.Player.RootClass})", RenderHelper.GetPlayerColor());
            RenderHelper.WriteLine($"Lv. {GameManager.Instance.Player.Stat.Level}",RenderHelper.GetStatColor(Enums.StatType.Level));
            RenderHelper.Write(RenderHelper.AlignCenterWithPadding("경험치", 15), ConsoleColor.White);
            RenderHelper.WriteLine(RenderHelper.AlignRightWithPadding($"{playerStat.Exp}", 9), RenderHelper.GetStatColor(Enums.StatType.Level));
            RenderHelper.Write(RenderHelper.AlignCenterWithPadding("경험치 획득률", 15), ConsoleColor.White);
            RenderHelper.WriteLine(RenderHelper.AlignRightWithPadding($"{((playerStat.ExpRate - 1.0) * 100).ToString("N0")} %", 9), RenderHelper.GetStatColor(Enums.StatType.Level));
            RenderHelper.Write(RenderHelper.AlignCenterWithPadding("공격력", 15), ConsoleColor.White);
            RenderHelper.WriteLine(RenderHelper.AlignRightWithPadding($"{playerStat.FinalAttack.ToString("N1")}", 9), RenderHelper.GetStatColor(Enums.StatType.Attack));
            RenderHelper.Write(RenderHelper.AlignCenterWithPadding("방어력", 15), ConsoleColor.White);
            RenderHelper.WriteLine(RenderHelper.AlignRightWithPadding($"{playerStat.FinalDefense.ToString("N1")}", 9), RenderHelper.GetStatColor(Enums.StatType.Defense));
            RenderHelper.Write(RenderHelper.AlignCenterWithPadding("크리티컬 확률", 15), ConsoleColor.White);
            RenderHelper.WriteLine(RenderHelper.AlignRightWithPadding($"{(playerStat.CriticalRate * 100).ToString("N0")} %", 9), RenderHelper.GetStatColor(Enums.StatType.CriticalRate));
            RenderHelper.Write(RenderHelper.AlignCenterWithPadding("크리티컬 데미지", 15), ConsoleColor.White);
            RenderHelper.WriteLine(RenderHelper.AlignRightWithPadding($"+{((playerStat.CriticalDamageRate - 1.0) * 100).ToString("N0")} %", 9), RenderHelper.GetStatColor(Enums.StatType.CriticalDamageRate));
            RenderHelper.Write(RenderHelper.AlignCenterWithPadding("명중률", 15), ConsoleColor.White);
            RenderHelper.WriteLine(RenderHelper.AlignRightWithPadding($"{(playerStat.AccuracyRate * 100).ToString("N0")} %", 9), RenderHelper.GetStatColor(Enums.StatType.Attack));
            RenderHelper.Write(RenderHelper.AlignCenterWithPadding("최종 데미지", 15), ConsoleColor.White);
            RenderHelper.WriteLine(RenderHelper.AlignRightWithPadding($"{(playerStat.FinalDamageMultiplier * 100).ToString("N0")} %", 9), RenderHelper.GetStatColor(Enums.StatType.FinalDamageMultiplier));
            RenderHelper.Write(RenderHelper.AlignCenterWithPadding("HP", 15), ConsoleColor.White);
            RenderHelper.WriteLine(RenderHelper.AlignRightWithPadding($"{playerStat.Health}/{playerStat.MaxHealth}", 9), RenderHelper.GetStatColor(Enums.StatType.Health));
            RenderHelper.Write(RenderHelper.AlignCenterWithPadding("MP", 15), ConsoleColor.White);
            RenderHelper.WriteLine(RenderHelper.AlignRightWithPadding($"{playerStat.MP}/{playerStat.MaxMP}", 9), RenderHelper.GetStatColor(Enums.StatType.MP));
            RenderHelper.Write(RenderHelper.AlignCenterWithPadding("Gold", 15), ConsoleColor.White);
            RenderHelper.WriteLine(RenderHelper.AlignRightWithPadding($"{GameManager.Instance.Player.Gold}", 9), ConsoleColor.DarkYellow);

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
