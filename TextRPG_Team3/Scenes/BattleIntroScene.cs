using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Managers;
using TextRPG_Team3.Data;
using TextRPG_Team3.Character;

namespace TextRPG_Team3.Scenes
{
    internal class BattleIntroScene : BaseScene
    {
        // 필요한 변수 생성
        List<EnemyCharacter> currentEnemies;
        Random random = new Random();
        
        public override void Render()
        {
            base.Render();

            Console.WriteLine("**Battle!!**");
            Console.WriteLine();

            // 문자열 변수 만들어서 적 정보 할당할 공간 만들기
            string enemyinfo = "";

            // List 반복문 넣어서 적 정보 갱신하기
            foreach (var enemy in currentEnemies)
            {
                // Level : 임시로 1~5 사이의 숫자 부여.
                int enemyLevel = random.Next(1, 6);

                enemyinfo += $"Lv. {enemyLevel}\t {enemy.Name.PadRight(5)}\t HP {enemy.CharacterStat.Health}\n";
            }
            Console.WriteLine(enemyinfo);
            Console.WriteLine();
            Console.WriteLine("[내 정보]");
            Console.WriteLine
                ($"Lv. {GameManager.Instance.Player.PlayerStat.Level}\t" +
                 $"{GameManager.Instance.Player.Name}\t");
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
                    SceneManager.Instance.CurrentScene = new PlayerPhaseScene();
                    break;
                default:
                    break;
            }
        }

        public BattleIntroScene()
        {
            // resourceManager로 EnemyDB 로드

            // 현재 에너미 리스트 만들어 놓고 랜덤으로 에너미 스폰
            SpawnRandomEnemies();
        }

        void SpawnRandomEnemies()
        {
            currentEnemies = new List<EnemyCharacter>();

            int enemycount = Random.Shared.Next(1, 5);

            for (int i = 0; i < enemycount; i++)
            {
                int randomint = Random.Shared.Next(1, 4);
                EnemyData enemyData = ResourceManager.Instance.GetEnemyData(randomint);

                EnemyCharacter newEnemy = new EnemyCharacter(enemyData);

                currentEnemies.Add(newEnemy);
            }
        }
    }
}
