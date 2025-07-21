using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Character;
using TextRPG_Team3.Managers;
using TextRPG_Team3.Stat;
using TextRPG_Team3.Utils;

namespace TextRPG_Team3.Scenes
{
    public class PokemonCenterScene : BaseScene
    {
        private int goldAmount = 500;
        public override void Render()
        {
            base.Render();

            RenderHelper.WriteLine("[포켓몬 센터]", ConsoleColor.Magenta);
            RenderHelper.WriteLine("이 곳에서 500 G를 지불하고 HP와 MP를 모두 회복할 수 있습니다.");
            RenderHelper.WriteLine();

            PlayerStatComponent playerStat = GameManager.Instance.Player.Stat as PlayerStatComponent;

            RenderHelper.WriteLine($"{RenderHelper.AlignLeftWithPadding("HP", 4)} : {RenderHelper.AlignRightWithPadding($"{playerStat.Health}/{playerStat.MaxHealth}", 8)}", ConsoleColor.Red);
            RenderHelper.WriteLine($"{RenderHelper.AlignLeftWithPadding("MP", 4)} : {RenderHelper.AlignRightWithPadding($"{playerStat.MP}/{playerStat.MaxMP}", 8)}", ConsoleColor.Blue);
            RenderHelper.WriteLine($"{RenderHelper.AlignLeftWithPadding("Gold", 4)} : {RenderHelper.AlignRightWithPadding($"{GameManager.Instance.Player.Gold} G", 8)}", ConsoleColor.DarkYellow);
            RenderHelper.WriteLine();

            RenderHelper.WriteLine("1. 확인",ConsoleColor.White);
            RenderHelper.WriteLine("0. 나가기", ConsoleColor.White);
            RenderHelper.WriteLine();

            PrintMsg();

        }

        public override void SelectMenu(int input)
        {
            Enums.CenterMenu selected = (Enums.CenterMenu)input;

            switch (selected)
            {
                case Enums.CenterMenu.Confirm:
                    if (GameManager.Instance.Player.Gold < goldAmount)
                    {
                        msg = "골드가 부족합니다.";
                        break;
                    }
                    GameManager.Instance.Player.Gold -= goldAmount;
                    Heal();
                    msg = "회복이 완료되었습니다.";
                    break;
                case Enums.CenterMenu.Out:
                    SceneManager.Instance.CurrentScene = new IntroScene();
                    break;
                default:
                    msg = "잘못된 입력입니다.";
                    break;
            }

        }

        private void Heal()
        {
            PlayerStatComponent playerStat = GameManager.Instance.Player.Stat as PlayerStatComponent;
            playerStat.Health = playerStat.MaxHealth;
            playerStat.MP = playerStat.MaxMP;
        }
    }
}
