using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Character;
using TextRPG_Team3.Data;

namespace TextRPG_Team3.Managers
{
    internal class SpawnManager
    {
        private static SpawnManager instance;
        public static SpawnManager Instance { get { return instance; } }

        public List<EnemyCharacter> CurrentEnemies;

        private Dictionary<int, List<EnemyData>> EnemiesByTier;


        public SpawnManager()
        {
            if (instance == null)
            {
                instance = this;
            }

            EnemiesByTier = new Dictionary<int, List<EnemyData>>();

            List<EnemyData> enemyList = ResourceManager.Instance.LoadJsonData<EnemyData>($"{ResourceManager.GAME_ROOT_DIR}/Data/EnemyDataList.json");

            if (enemyList != null)
            {
                foreach (EnemyData enemyData in enemyList)
                {
                    int tier = enemyData.Tier;

                    if (!EnemiesByTier.ContainsKey(tier))
                    {
                        EnemiesByTier.Add(tier, new List<EnemyData>());
                    }

                    EnemiesByTier[tier].Add(enemyData);

                }
            }
        }


        public void GenerateStage(int currentStage)
        {
            if (CurrentEnemies != null) return;
            
            CurrentEnemies = new List<EnemyCharacter>();
            

            if (currentStage % 10 == 0)
            {
                // 특수 스테이지 정보 로드
                StageData stageData = ResourceManager.Instance.LoadJsonData<StageData>($"{ResourceManager.GAME_ROOT_DIR}/Data/StageDataList.json")[currentStage / 10 - 1];

                for (int i = 0; i < stageData.Enemies.Count; ++i)
                {
                    EnemyCharacter enemy = new EnemyCharacter(ResourceManager.Instance.GetEnemyData(stageData.Enemies[i]));
                    enemy.SetLevel(stageData.Levels[i]);

                    CurrentEnemies.Add(enemy);
                }

                return;
            }

            // min은 포함 max는 미포함 (min <= a < max)
            int minCount;
            int maxCount;
            int minLevel;
            int maxLevel;
            int minTier;
            int maxTier;

            if (0 < currentStage && currentStage < 10)
            {
                minCount = 1;
                maxCount = 4;
                minLevel = 1;
                maxLevel = 11;
                minTier = 1;
                maxTier = 2;
            }
            else if (10 < currentStage && currentStage < 20)
            {
                minCount = 2;
                maxCount = 6;
                minLevel = 6;
                maxLevel = 16;
                minTier = 1;
                maxTier = 3;
            }
            else if (20 < currentStage && currentStage < 30)
            {
                minCount = 3;
                maxCount = 7;
                minLevel = 12;
                maxLevel = 23;
                minTier = 2;
                maxTier = 4;
            }
            else if (30 < currentStage && currentStage < 40)
            {
                minCount = 4;
                maxCount = 8;
                minLevel = 17;
                maxLevel = 28;
                minTier = 3;
                maxTier = 5;
            }
            else if (40 < currentStage && currentStage < 50)
            {
                minCount = 5;
                maxCount = 9;
                minLevel = 22;
                maxLevel = 34;
                minTier = 4;
                maxTier = 6;
            }
            else
            {
                minCount = 0;
                maxCount = 0;
                minLevel = 0;
                maxLevel = 0;
                minTier = 0;
                maxTier = 0;
            }

            int count = Random.Shared.Next(minCount, maxCount);

            for (int i = 0; i < count; i++)
            {
                int level = Random.Shared.Next(minLevel, maxLevel);
                int tier = Random.Shared.Next(minTier, maxTier);

                List<EnemyData> enemies = EnemiesByTier[tier];
                EnemyData enemyData = enemies[Random.Shared.Next(0, enemies.Count)];
                EnemyCharacter enemy = new EnemyCharacter(enemyData);
                enemy.SetLevel(level);

                CurrentEnemies.Add(enemy);
            }

        }
        
        public int SumofEnemyLevel() //적의 총 레벨을 반환함.
        {
            int exp = 0;
            foreach (EnemyCharacter enemy in CurrentEnemies)
            {
                exp += enemy.Stat.Level;
            }
            return exp;
        }
        public bool HasEnemies()
        {
            if (CurrentEnemies == null)
            {
                return false;
            }

            foreach (var enemy in CurrentEnemies)
            {
                if (enemy.IsAlive)
                {
                    return true;
                }
            }

            //CurrentEnemies = null;


            return false;
        }
    }
}
