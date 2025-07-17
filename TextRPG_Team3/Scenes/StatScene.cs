using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Managers;

namespace TextRPG_Team3.Scenes
{
    internal class StatScene : BaseScene
    {
        public override void Render()
        {
            base.Render();
            string extraAttackStr = (GameManager.Instance.Player.Stat.ExtraAttack == 0) ? "" : $" + {GameManager.Instance.Player.Stat.ExtraAttack}";
            string extraDefenseStr = (GameManager.Instance.Player.Stat.ExtraDefense == 0) ? "" : $" + {GameManager.Instance.Player.Stat.ExtraDefense}";
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();


            Console.WriteLine($"{GameManager.Instance.Player.Name} ({GameManager.Instance.Player.RootClass})");
            Console.WriteLine($"Lv. {GameManager.Instance.Player.Stat.Level}");
            Console.WriteLine($"경험치 : {GameManager.Instance.Player.Stat.exp}");
            Console.WriteLine($"공격력 : {GameManager.Instance.Player.Stat.BaseAttack}{extraAttackStr}");
            Console.WriteLine($"방어력 : {GameManager.Instance.Player.Stat.BaseDefense}{extraDefenseStr}");
            Console.WriteLine($"체력 : {GameManager.Instance.Player.Stat.Health}");
            Console.WriteLine($"Gold : {GameManager.Instance.Player.Gold} G");
            Console.WriteLine();

            Console.WriteLine("1. 인벤토리");
            Console.WriteLine("0. 나가기");
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
