using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Character;
using TextRPG_Team3.Managers;
using TextRPG_Team3.Scenes;
using static Enums;

namespace TextRPG_Team3.Scenes
{
    internal class VictoryScene : BaseScene
    {
        int exp = SpawnManager.Instance.SumofEnemyLevel(); //얻은 경험치는 이 변수를 사용하시면 되겠습니다.
                                                           //필요에 따라 프로퍼티를 만드시거나 public 필드로 선언해주셔도 괜찮습니다!
        //public void CheckVictory(List<EnemyCharacter> enemies)
        //{
        //    // 모든 몬스터의 isAlive가 false면 victoryscene 호출
        //    bool allEnemiesDead = true;
        //    foreach (var enemy in enemies)
        //    {
        //        if (enemy.IsAlive)
        //        {
        //            allEnemiesDead = false;
        //            break;
        //        }
        //    }

        //    if (allEnemiesDead)
        //    {
        //        Render();
        //    }
        //}

      

        public override void Render()
        {
            base.Render();
            Console.WriteLine("============== Battle Result ==============");
            Console.WriteLine("                 [  VICTORY  ]            \n");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"플레이어: {GameManager.Instance.Player.Name}");
            Console.WriteLine($"레벨: {GameManager.Instance.Player.Stat.Level}");
            Console.WriteLine($"HP: {GameManager.Instance.Player.Stat.Health} / {GameManager.Instance.Player.Stat.MaxHealth}");
            Console.WriteLine($"보유 골드: {GameManager.Instance.Player.Gold} G");
            Console.WriteLine("------------------------------------------\n");
            Console.WriteLine("0. 다음");
            Console.WriteLine("==========================================");
        }
        private void ClearEnemyList() //적들 정보를 지우고 싶을 때 사용해 주세요!
        {
            SpawnManager.Instance.CurrentEnemies = null;
        }
        public override void SelectMenu(int input)
        {
            Enums.VictoryScene victoryScene = (Enums.VictoryScene)input;

            switch (victoryScene)
            {
                case Enums.VictoryScene.Next:
                    SceneManager.Instance.CurrentScene = new IntroScene();
                    break;
                default:
                    msg = "잘못된 입력입니다.";
                    break;
            }
        }
    
    }
}
