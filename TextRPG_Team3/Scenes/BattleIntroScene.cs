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
        List<EnemyCharacter> currentEnemies;
        public override void Render()
        {
            base.Render();

            // 요구 사항 맞춰서 Render 구현 굳이 플레이어 페이즈 , 에너미 페이즈 나누지 말고 그냥 플레이어 선턴으로 번갈아가면서 공격하는걸로

            Console.WriteLine("이 곳은 BattleScene입니다.");
            Console.WriteLine();
            foreach(EnemyCharacter enemy in currentEnemies)
            {
                Console.WriteLine($"{enemy.Name} ");
            }
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
        }

        public override void SelectMenu(int input)
        {
            Enums.BattleMenu selectedNumber = (Enums.BattleMenu)input;

            switch (selectedNumber)
            {
                case Enums.BattleMenu.Out:
                    SceneManager.Instance.CurrentScene = new EnemyPhaseScene(currentEnemies);
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
            SpawnRandomEnemies();
        }

        public BattleIntroScene(List<EnemyCharacter> currentEnemies)
        {
            this.currentEnemies = currentEnemies;
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
