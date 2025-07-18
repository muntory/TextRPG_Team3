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

            RenderHelper.WriteLine("인벤토리 - 장착관리",ConsoleColor.DarkYellow);
            RenderHelper.WriteLine("보유 중인 아이템을 관리할 수 있습니다.", ConsoleColor.White);
            
            RenderHelper.MakeLine();

            if (ItemIDs.Count == 0)
            {
                RenderHelper.WriteLine("보유 중인 아이템이 없습니다.", ConsoleColor.DarkGray);
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

                        RenderHelper.Write($"- {i + 1} {RenderHelper.AlignLeftWithPadding(equipped + itemData.Name, 17)} {RenderHelper.AlignLeftWithPadding(itemCountInterface, 3)} | ",ConsoleColor.White);

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

                        RenderHelper.WriteLine(" | " + itemData.Description,ConsoleColor.White);
                    }
                }
            }
            RenderHelper.MakeLine();

            RenderHelper.WriteLine("0. 나가기",ConsoleColor.White);
            Console.WriteLine();
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
                    if (ItemManager.Instance.IsPotion(ItemIDs[input - 1]))
                    {
                        msg = "회복 아이템은 장착할 수 없습니다!";
                    }
                    else
                    {
                        ItemManager.Instance.EquipOrDeEquip(ItemIDs[input - 1]);
                    }
                    break;
            }
        }
    }
}
