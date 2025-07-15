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
            string extraAttackStr = (GameManager.Instance.Player.CharacterStat.ExtraAttack == 0) ? "" : $" + {GameManager.Instance.Player.CharacterStat.ExtraAttack}";
            string extraDefenseStr = (GameManager.Instance.Player.CharacterStat.ExtraDefense == 0) ? "" : $" + {GameManager.Instance.Player.CharacterStat.ExtraDefense}";
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();


            Console.WriteLine($"Lv. {GameManager.Instance.Player.CharacterStat.Level}");
            Console.WriteLine($"{GameManager.Instance.Player.Name}");
            Console.WriteLine($"공격력 : {GameManager.Instance.Player.CharacterStat.BaseAttack}{extraAttackStr}");
            Console.WriteLine($"방어력 : {GameManager.Instance.Player.CharacterStat.BaseDefense}{extraDefenseStr}");
            Console.WriteLine($"체력 : {GameManager.Instance.Player.CharacterStat.Health}");
            Console.WriteLine($"Gold : {GameManager.Instance.Player.Gold} G");
            Console.WriteLine();

            Console.WriteLine("0. 나가기");
            Console.WriteLine();

        }

        public override void SelectMenu(int input)
        {
            Enums.StatMenu selectedNumber = (Enums.StatMenu)input;

            switch (selectedNumber)
            {
                case Enums.StatMenu.Out:
                    SceneManager.Instance.CurrentScene = new IntroScene();
                    break;
                default:
                    break;
            }
        }
    }
}
