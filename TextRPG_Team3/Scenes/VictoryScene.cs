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

                TotalExp += data.Exp;
                TotalGold += data.Gold;
            }

            GameManager.Instance.Player.Gold += TotalGold;
            GameManager.Instance.Player.Stat.exp += TotalExp;

            GameManager.Instance.MaxExperience();
            CharacterStatComponent stat = new CharacterStatComponent();

            Console.WriteLine("\n============== Battle Result ==============\n");
            Console.WriteLine("               [  VICTORY  ]                \n");
            Console.WriteLine("------------------------------------------\n");
            Console.WriteLine("[캐릭터 정보]");
            Console.WriteLine($"레벨: {GameManager.Instance.Player.Stat.Level}");
            Console.WriteLine($"경험치: {GameManager.Instance.Player.Stat.exp - ((GameManager.Instance.Player.Stat.exp - TotalExp) + TotalExp )} -> {GameManager.Instance.Player.Stat.exp}");
            Console.WriteLine($"HP: {GameManager.Instance.Player.Stat.MaxHealth} -> {GameManager.Instance.Player.Stat.MaxHealth - (GameManager.Instance.Player.Stat.MaxHealth - GameManager.Instance.Player.Stat.Health)}\n");
            Console.WriteLine("[흭득 아이템]");
            Console.WriteLine($"흭득한 골드: {TotalGold}");
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
