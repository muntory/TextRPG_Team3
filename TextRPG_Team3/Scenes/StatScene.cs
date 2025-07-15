using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Managers;
using static Program;

namespace TextRPG_Team3.Scenes
{
    internal class StatScene : BaseScene
    {
        public StatScene()
        {
            MenuMin = 0;
            MenuMax = 0;
        }
        public override void Render()
        {
            base.Render();
            string extraAttackStr = (GameManager.Instance.Player.CharacterStat.ExtraAttack == 0) ? "" : $" + {GameManager.Instance.Player.CharacterStat.ExtraAttack}";
            string extraDefenseStr = (GameManager.Instance.Player.CharacterStat.ExtraDefense == 0) ? "" : $" + {GameManager.Instance.Player.CharacterStat.ExtraDefense}";
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");

            Console.WriteLine($"Lv. {GameManager.Instance.Player.CharacterStat.Level}");
            Console.WriteLine($"{GameManager.Instance.Player.Name}");
            Console.WriteLine($"공격력 : {GameManager.Instance.Player.CharacterStat.BaseAttack}{extraAttackStr}");
            Console.WriteLine($"방어력 : {GameManager.Instance.Player.CharacterStat.BaseDefense}{extraDefenseStr}");
            Console.WriteLine($"체력 : {GameManager.Instance.Player.CharacterStat.Health}");
            Console.WriteLine($"Gold : {GameManager.Instance.Player.Gold} G");
            Console.WriteLine("\n0. 나가기");
        }

        public override void SelectMenu(int num)
        {
            StatMenuE selectedNumber = new StatMenuE();

            selectedNumber = (StatMenuE)num;

            switch (selectedNumber)
            {
                case StatMenuE.Out:
                    SceneManager.Instance.CurrentScene = new IntroScene(); break;
            }
        }
    }
}
