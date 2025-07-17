using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Managers;

namespace TextRPG_Team3.Scenes
{
    internal class InventoryScene : BaseScene
    {
        public override void Render()
        {
            base.Render();
            Console.WriteLine("인벤토리");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("[아이템 목록]");
            Console.WriteLine();

            // 소지 중인 아이템 ID 목록 전체 가져오기
            List<int> ItemIDs = ItemManager.Instance.AllHaveItemIDs();

            if (ItemIDs.Count == 0)
            {
                Console.WriteLine("보유 중인 아이템이 없습니다.");
            }
            else
            {
                for (int i = 0; i < ItemIDs.Count; i++)
                {
                    int itemID = ItemIDs[i];

                    ItemData itemData = ItemManager.Instance.GetItemData(itemID);

                    int ItemCount = ItemManager.Instance.GetItemCount(itemID);

                    if (itemData != null)
                    {
                        // 개수 1개면 생략, 2개 이상부터 표시
                        string itemCountInterface = (ItemCount > 1) ? $"X {ItemCount}" : "";

                        // 스탯 타입 한글로 반환
                        string statType = "";

                        if (itemData.StatType == Enums.StatType.Attack)
                            statType = "공격력";
                        else if (itemData.StatType == Enums.StatType.Defense)
                            statType = "방어력";
                        else if (itemData.StatType == Enums.StatType.Health)
                            statType = "체력";

                        Console.WriteLine($"- {itemData.Name} {itemCountInterface} | {statType} + {itemData.Value} | {itemData.Description}");
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
        }

        public override void SelectMenu(int input)
        {
            Enums.InventoryMenu selectedNumber = (Enums.InventoryMenu)input;

            switch (selectedNumber)
            {
                case Enums.InventoryMenu.Back:
                    SceneManager.Instance.CurrentScene = new IntroScene();
                    break;
                case Enums.InventoryMenu.Set :
                    
                    break;
            }
        }
    }
}
