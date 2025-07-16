using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Character;
using TextRPG_Team3.Data;
using TextRPG_Team3.Managers;
using TextRPG_Team3.Utils;

namespace TextRPG_Team3.Scenes
{
    internal class BattleIntroScene : BaseScene
    {
        // 필요한 변수 생성
        
        Random random = new Random();
        
        public override void Render()
        {
            base.Render();

            Console.WriteLine("Battle!!");
            Console.WriteLine();

            // 문자열 변수 만들어서 적 정보 할당할 공간 만들기
            string enemyinfo = "";

            // List 반복문 넣어서 적 정보 갱신하기
            foreach (var enemy in SpawnManager.Instance.currentEnemies)
            {
                enemyinfo += $"Lv. {enemy.CharacterStat.Level} {RenderHelper.PadLeftToWidth(enemy.Name, 14)} {(enemy.IsAlive ? $"HP {enemy.CharacterStat.Health}" : "Dead")}";
            }
            Console.WriteLine(enemyinfo);
            Console.WriteLine();
            Console.WriteLine("[내 정보]");
            Console.WriteLine
                ($"Lv. {GameManager.Instance.Player.PlayerStat.Level}\t" +
                 $"{GameManager.Instance.Player.Name}");
            Console.WriteLine
                ($"HP {GameManager.Instance.Player.PlayerStat.Health}/100");
            Console.WriteLine();
            Console.WriteLine("1. 공격");
            Console.WriteLine();
        }

        public override void SelectMenu(int input)
        {
            Enums.BattleMenu selectedNumber = (Enums.BattleMenu)input;

            switch (selectedNumber)
            {
                case Enums.BattleMenu.Attack:
                    SceneManager.Instance.CurrentScene = new PlayerPhaseScene(SpawnManager.Instance.currentEnemies);
                    break;
                default:
                    msg = "잘못된 입력입니다.";
                    break;
            }
        }

        public BattleIntroScene()
        {
            // resourceManager로 EnemyDB 로드

            // 현재 에너미 리스트 만들어 놓고 랜덤으로 에너미 스폰
            SpawnManager.Instance.SpawnRandomEnemies();
        }

        public BattleIntroScene(List<EnemyCharacter> currentEnemies)
        {
            SpawnManager.Instance.currentEnemies = currentEnemies;
        }
    }
}
