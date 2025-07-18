using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Managers;
using TextRPG_Team3.Utils;

namespace TextRPG_Team3.Scenes
{
    internal class ItemEquipScene : BaseScene
    {
        List<int> ItemIDs = ItemManager.Instance.AllHaveItemIDs();

        public override void Render()
        {
            base.Render();

            Console.WriteLine("인벤토리 - 장착관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");



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
                        string equipped = itemData.IsEquipped ? "[E] " : "";

                        Console.WriteLine($"- {i + 1} {equipped} {RenderHelper.AlignLeftWithPadding(itemData.Name, 15)} {RenderHelper.AlignLeftWithPadding(itemCountInterface, 3)} | {RenderHelper.AlignLeftWithPadding(statType, 7)} + {RenderHelper.AlignLeftWithPadding(itemData.Value.ToString(), 2, ConsoleColor.DarkCyan)} | {itemData.Description}");
                    }
                }
            }
            PrintMsg();
        }

        public override void SelectMenu(int input)
        {
            if (0 > input || input > ItemIDs.Count)
            {
                msg = "잘못된 입력입니다.";
                return;
            }

            Enums.ItemEquipMenu itemMenu = (Enums.ItemEquipMenu)input;
            switch (itemMenu)
            {
                case Enums.ItemEquipMenu.Out:
                    SceneManager.Instance.CurrentScene = new InventoryScene();
                    break;

                default:
                    ItemManager.Instance.EquipOrDeEquip(ItemIDs[input - 1]);
                    break;
            }
        }
    }
}
