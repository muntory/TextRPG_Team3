using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Character;
using TextRPG_Team3.Data;
using TextRPG_Team3.Managers;
using TextRPG_Team3.Scenes;
using TextRPG_Team3.Stat;
using static Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TextRPG_Team3.Scenes
{
    internal class VictoryScene : BaseScene
    {
       
      
        public override void Render()
        {
            
            base.Render();
            int TotalGold = 0;
            int TotalExp = 0;
            foreach (var enemy in SpawnManager.Instance.CurrentEnemies)
            {
                EnemyData data = ResourceManager.Instance.GetEnemyData(enemy.EnemyID);

                TotalExp = data.Exp;
                TotalGold += data.Gold;
            }

            GameManager.Instance.Player.Gold += TotalGold;
            GameManager.Instance.Player.Stat.exp += TotalExp;
           
            PlayerStatComponent stat = (PlayerStatComponent)GameManager.Instance.Player.Stat;
            int exp = SpawnManager.Instance.SumofEnemyLevel();
            stat.exp += exp;
            stat.MP += 10;

            if (stat.exp >= 100)
            {
                stat.exp -= 100;
                stat.Level += 1;
                stat.BaseDefense += 1.0;
                stat.BaseAttack += 0.5;
                Console.WriteLine("============== Level Up ==============\n");
                Console.WriteLine($"축하합니다 {stat.Level}레벨로 레벨업하셨습니다!");
                Console.WriteLine("기본공격력 0.5 방어력 1이 증가하셨습니다\n");
                Console.WriteLine("============== Level Up ==============\n");

            }
            
            Console.WriteLine("\n============== Battle Result ==============\n");
            Console.WriteLine("               [  VICTORY  ]                \n");
            Console.WriteLine("------------------------------------------\n");
            Console.WriteLine($"흭득한 골드: {TotalGold}");
            Console.WriteLine($"흭득한 경험치: {TotalExp}");
            Console.WriteLine("\n==========================================\n");
            Console.WriteLine($"플레이어: {GameManager.Instance.Player.Name}");
            Console.WriteLine($"레벨: {GameManager.Instance.Player.Stat.Level}");
            Console.WriteLine($"경험치: {GameManager.Instance.Player.Stat.exp}");
            Console.WriteLine($"HP: {GameManager.Instance.Player.Stat.Health} / {GameManager.Instance.Player.Stat.MaxHealth}");
            Console.WriteLine($"보유 골드: {GameManager.Instance.Player.Gold} G");
            Console.WriteLine("------------------------------------------\n");
            Console.WriteLine("0. 다음");
            Console.WriteLine("==========================================");

            ClearEnemyList();
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
