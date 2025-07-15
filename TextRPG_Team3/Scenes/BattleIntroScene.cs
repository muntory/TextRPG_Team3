using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Managers;
using TextRPG_Team3.Data;

namespace TextRPG_Team3.Scenes
{
    internal class BattleIntroScene : BaseScene
    {
        Dictionary<int, EnemyData> EnemyDB;

        public override void Render()
        {
            base.Render();

            // 요구 사항 맞춰서 Render 구현 굳이 플레이어 페이즈 , 에너미 페이즈 나누지 말고 그냥 플레이어 선턴으로 번갈아가면서 공격하는걸로

            Console.WriteLine("이 곳은 BattleScene입니다.");
            Console.WriteLine();

            Console.WriteLine("0. 나가기");
            Console.WriteLine();

        }

        public override void SelectMenu(int input)
        {
            Enums.BattleMenu selectedNumber = (Enums.BattleMenu)input;

            switch (selectedNumber)
            {
                case Enums.BattleMenu.Out:
                    SceneManager.Instance.CurrentScene = new IntroScene();
                    break;
                default:
                    break;
            }
        }

        public BattleIntroScene()
        {
            // resourceManager로 EnemyDB 로드

            // 현재 에너미 리스트 만들어 놓고 랜덤으로 에너미 스폰
        }
    }
}
