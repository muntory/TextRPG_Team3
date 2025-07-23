using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Managers;
using TextRPG_Team3.Utils;

namespace TextRPG_Team3.Scenes
{
    internal class InventoryScene : BaseScene
    {
        public override void Render()
        {
            base.Render();
            RenderHelper.WriteLine("인벤토리", ConsoleColor.DarkYellow);
            RenderHelper.WriteLine("[아이템 목록]", ConsoleColor.White);

            RenderHelper.MakeLine();

            // 소지 중인 아이템 ID 목록 전체 가져오기
            List<int> ItemIDs = ItemManager.Instance.AllHaveItemIDs();

            if (ItemIDs.Count == 0)
            {
                Console.WriteLine("보유 중인 아이템이 없습니다.");
                Console.WriteLine();
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

                        string equipped = itemData.IsEquipped ? "[E] " : "";

                        // 스탯 타입 한글로 반환
                        string statType = "";

                        RenderHelper.Write($"- {RenderHelper.AlignLeftWithPadding(equipped + itemData.Name, 17)} {RenderHelper.AlignLeftWithPadding(itemCountInterface, 3)} | ", ConsoleColor.White);

                        if (itemData.StatType == Enums.StatType.Attack)
                        {
                            statType = "공격력";
                            RenderHelper.Write($"{RenderHelper.AlignLeftWithPadding(statType, 7)} + {RenderHelper.AlignLeftWithPadding(itemData.Value.ToString(), 2)}", ConsoleColor.Yellow);
                        }
                        else if (itemData.StatType == Enums.StatType.Defense)
                        {
                            statType = "방어력";
                            RenderHelper.Write($"{RenderHelper.AlignLeftWithPadding(statType, 7)} + {RenderHelper.AlignLeftWithPadding(itemData.Value.ToString(), 2)}", ConsoleColor.Cyan);
                        }
                        else if (itemData.StatType == Enums.StatType.Health)
                        {
                            statType = "체력";
                            RenderHelper.Write($"{RenderHelper.AlignLeftWithPadding(statType, 7)} + {RenderHelper.AlignLeftWithPadding(itemData.Value.ToString(), 2)}", ConsoleColor.Red);
                        }

                        RenderHelper.WriteLine(" | " + itemData.Description, ConsoleColor.White);
                       
                    }
                }
                RenderHelper.MakeLine();
                RenderHelper.WriteLine("[뱃지 목록]", ConsoleColor.White);
                var badgeList = GameManager.Instance.BadgeList;
                if (badgeList.Count == 0)
                {
                    RenderHelper.WriteLine("보유 중인 뱃지가 없습니다.", ConsoleColor.Gray);
                }
                else
                {
                    foreach (var badge in badgeList)
                    {
                        RenderHelper.WriteLine($"- {badge.Name}", ConsoleColor.Yellow);
                    }
                }

            }
            RenderHelper.MakeLine();

            RenderHelper.WriteLine("1. 장착 관리",ConsoleColor.White);
            RenderHelper.WriteLine("0. 나가기", ConsoleColor.White);
            Console.WriteLine();
        }

        public override void SelectMenu(int input)
        {
            Enums.InventoryMenu selectedNumber = (Enums.InventoryMenu)input;

            switch (selectedNumber)
            {
                case Enums.InventoryMenu.Back:
                    SceneManager.Instance.CurrentScene = new StatScene();
                    break;
                case Enums.InventoryMenu.Set :
                    SceneManager.Instance.CurrentScene = new ItemEquipScene();
                    break;
            }
        }
    }
}
