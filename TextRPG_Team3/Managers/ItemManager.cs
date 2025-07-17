using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team3.Managers
{
    internal class ItemManager
    {
        private static ItemManager instance;
        public static ItemManager Instance { get { return instance; } }

        public ItemManager() 
        {
            if (instance == null)
            {
                instance = this;
            }

            // 생성자 -> 인벤토리 초기화
            PlayerInventory = new Dictionary<int, int>();

            LoadItemData();
        }
    // ------------------------------------------- 평범한 싱글톤

        // 플레이어 보유 중인 아이템 (Item ID, 개수)
        public Dictionary<int, int> PlayerInventory;

        private List<ItemData> itemDataList;

        // 아이템 데이터 로드 -> 생성자 -> 데잍터 한 번 로드 후 메모리에 저장.
        private void LoadItemData()
        {
            itemDataList = ResourceManager.Instance.LoadJsonData<ItemData>($"{ResourceManager.GAME_ROOT_DIR}/Data/ItemDataList.json");
        }

        // 아이템 정보 받아오는 메서드
        public ItemData GetItemData (int itemID)
        {
            for (int i = 0; i < itemDataList.Count; i++)
            {
                if (itemDataList[i].Id == itemID)
                {
                    return itemDataList[i];
                }
            }
            return null;
        }

        // 아이템이 존재하는 지 확인하는 메서드
        public bool IsItemExist(int itemID)
        {
            return GetItemData(itemID) != null;
        }

        // 아이템 증가 메서드
        public void AddItem(int itemID, int count = 1)
        { 
            if (!IsItemExist(itemID)) return;

            if (PlayerInventory.ContainsKey(itemID))
            {
                PlayerInventory[itemID] += count;
            }
            else
            {
                PlayerInventory[itemID] = count;
            }
        }

        // 아이템 감소 메서드
        public bool RemoveItem(int itemID, int count = 1)
        {
            if (PlayerInventory.ContainsKey(itemID))
            {
                int currentCount = PlayerInventory[itemID];

                if (currentCount < count)
                {
                    return false;
                }

                PlayerInventory[itemID] -= count;

                if (PlayerInventory[itemID] == 0)
                {
                    PlayerInventory.Remove(itemID);
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        // 아이템 개수 반환 메서드
        public int GetItemCount(int itemID)
        {
            if (PlayerInventory.ContainsKey(itemID))
            {
                return PlayerInventory[itemID];
            }
            return 0;
        }

        // 소지 중인 아이템 ID 목록 반환
        public List<int> AllHaveItemIDs()
        {
            List<int> itemIDs = new List<int>();

            foreach (int itemID in PlayerInventory.Keys)
            {
                itemIDs.Add(itemID);
            }

            return itemIDs;
        }

        // 아이템 소지 중인지 여부 판단
        public bool HaveItem(int itemID)
        {
            return PlayerInventory.ContainsKey(itemID) && PlayerInventory[itemID] > 0;
        }
    }
}
