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
using TextRPG_Team3.Utils;
using static Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TextRPG_Team3.Scenes
{
    internal class VictoryScene : BaseScene
    {
        private (int potionCount, List<string> droppedEquipNames) DropItem()
        {
            Random rand = new Random();

            int potionCount = rand.Next(1, 4); // 전투 승리시 1개~3개 포션 흭득
            ItemManager.Instance.AddItem(100, potionCount);

            List<ItemData> Allequip = new List<ItemData>(); // JSON에 있는 정보를 가져오는 리스트

            foreach (var equipment in ItemManager.Instance.GetAllItemData())
            {
                if (equipment.Value.Type != ItemType.Potion) //  만약 저장한아이템 타입이 Potion이 아니라면 
                {
                     Allequip.Add(equipment.Value); // 포션이 아닌 장비들을 리스트에 저장
                }
            }

            int acquireCount = rand.Next(0, 3);
            List<string> equipName = new List<string>();

            for (int i = 0; i < equipName.Count; i++)
            {
                if (Allequip.Count == 0) break;
            }

            int index = rand.Next(0, Allequip.Count);
            ItemData Chosen = Allequip[index];

            if (rand.NextDouble() < 0.5)
            {
                ItemManager.Instance.AddItem(Chosen.Id, 1); //50 프로 확률로 아이템 한개 저장
                equipName.Add(Chosen.Name); // 이름에도 저장
            }

            return (potionCount, equipName);
        }

        public override void Render()
        {

            base.Render();
            DropItem();
            var (potionCount, droppedEquipNames) = DropItem();
            int count = 0;
            int TotalGold = 0;

            foreach (var enemy in SpawnManager.Instance.CurrentEnemies)
            {
                EnemyData data = ResourceManager.Instance.GetEnemyData(enemy.EnemyID);

                TotalGold += (int)(data.Gold + data.Gold * 0.05 * (enemy.Stat.Level - 1));
                count++;
            }

            GameManager.Instance.Player.Gold += TotalGold;

            PlayerStatComponent stat = (PlayerStatComponent)GameManager.Instance.Player.Stat;
            int exp = SpawnManager.Instance.SumofEnemyLevel();
            double prevexp = stat.exp;
            int prevLevel = stat.Level;
            stat.exp += exp;
            stat.MP += 10;
            GameManager.Instance.MaxExperience();
            CharacterStatComponent Exp = new CharacterStatComponent();

            RenderHelper.WriteLine("\n============== Battle Result ============== \n");
            RenderHelper.WriteLine(("                [  VICTORY  ]                \n"),ConsoleColor.DarkYellow);
            RenderHelper.WriteLine("---------------------------------------------\n");
            RenderHelper.Write("몬스터 ");
            RenderHelper.Write($"{count}마리",ConsoleColor.DarkRed);
            RenderHelper.WriteLine("를 처치했습니다");
            RenderHelper.WriteLine("\t[캐릭터 정보]");
            RenderHelper.WriteLine($"Lv. {GameManager.Instance.Player.Stat.Level}",RenderHelper.GetStatColor(Enums.StatType.Level));
            RenderHelper.Write($"경험치\t:");
            RenderHelper.Write($" Lv{prevLevel}", RenderHelper.GetStatColor(Enums.StatType.Level));
            RenderHelper.Write($" {prevexp:0.}", ConsoleColor.Yellow);
            RenderHelper.Write($" -> Lv{GameManager.Instance.Player.Stat.Level}. ");
            RenderHelper.WriteLine($"{GameManager.Instance.Player.Stat.exp:0.}",ConsoleColor.Yellow);
            RenderHelper.Write($"HP\t:");
            RenderHelper.Write($" {GameManager.Instance.Player.Stat.MaxHealth}", RenderHelper.GetStatColor(Enums.StatType.Health));
            RenderHelper.Write("-> ");
            RenderHelper.WriteLine($"{GameManager.Instance.Player.Stat.MaxHealth - (GameManager.Instance.Player.Stat.MaxHealth - GameManager.Instance.Player.Stat.Health)}\n", RenderHelper.GetStatColor(Enums.StatType.Health));
            RenderHelper.WriteLine("\t[흭득 아이템]");
            RenderHelper.Write("흭득한 골드\t: ");
            RenderHelper.Write($"{TotalGold}", ConsoleColor.DarkYellow);
            RenderHelper.WriteLine("G");
            RenderHelper.WriteLine($"흭득한 포션\t: {potionCount}개");
            if (droppedEquipNames.Count > 0)
            {
                foreach (var equipment in droppedEquipNames)
                {
                    RenderHelper.Write("흭득한 장비\t- ");
                    RenderHelper.WriteLine($"{equipment}\n",ConsoleColor.DarkGray);
                }
            }
            RenderHelper.WriteLine("------------------------------------------\n");
            RenderHelper.WriteLine("0. 다음");
            RenderHelper.WriteLine("==========================================");

            ClearEnemyList();
        }
        private void ClearEnemyList() //적들 정보를 지우고 싶을 때 사용해 주세요!
        {
            SpawnManager.Instance.CurrentEnemies = null;
        }
        public override void SelectMenu(int input)
        {
            GameManager.CurrentStage++;
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