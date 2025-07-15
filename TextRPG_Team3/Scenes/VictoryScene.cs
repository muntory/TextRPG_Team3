using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Character;
using TextRPG_Team3.Managers;
using TextRPG_Team3.Scenes;

namespace TextRPG_Team3.Scenes
{
    internal class VictoryScene : BaseScene
    {
        public void CheckVictory(List<EnemyCharacter> enemies)
        {
            // 모든 몬스터의 isAlive가 false면 victoryscene 호출
            bool allEnemiesDead = true;
            foreach (var enemy in enemies)
            {
                if (enemy.IsAlive)
                {
                    allEnemiesDead = false;
                    break;
                }
            }

            if (allEnemiesDead)
            {
                ShowVictoryScene(GameManager.Instance.Player);
            }
        }



        public void ShowVictoryScene(PlayerCharacter Player)
        {
            Console.Clear();
            Console.WriteLine("============== Battle Result ==============");
            Console.WriteLine("                 [  VICTORY  ]            \n");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"플레이어: {Player.Name}");
            Console.WriteLine($"레벨: {Player.PlayerStat.Level}");
            Console.WriteLine($"HP: {Player.PlayerStat.Health} / {Player.PlayerStat.MaxHealth}");
            Console.WriteLine($"보유 골드: {Player.Gold} G");
            Console.WriteLine("------------------------------------------\n");
            Console.WriteLine("0. 다음");
            Console.WriteLine("==========================================");
        }
    }
}
