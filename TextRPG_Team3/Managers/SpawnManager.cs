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

        Random rand = new Random();

        public SpawnManager()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        public static SpawnManager Instance { get { return instance; } }

        public List<EnemyCharacter> CurrentEnemies;

        public void SpawnRandomEnemies()
        {
            if (CurrentEnemies != null)
            {
                return;
            }

            CurrentEnemies = new List<EnemyCharacter>();

            int enemycount = rand.Next(1, 5);

            for (int i = 0; i < enemycount; i++)
            {
                int randomint = Random.Shared.Next(1, 4);
                EnemyData enemyData = ResourceManager.Instance.GetEnemyData(randomint);

                EnemyCharacter newEnemy = new EnemyCharacter(enemyData);

                newEnemy.CharacterStat.Level = rand.Next(1, 11);

                currentEnemies.Add(newEnemy);
            }
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

            CurrentEnemies = null;
            return false;
        }
    }
}
