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

            AddStartingItems();
        }
    // ------------------------------------------- 평범한 싱글톤

        // 플레이어 보유 중인 아이템 (Item ID, 개수)
        public Dictionary<int, int> PlayerInventory;

        private Dictionary<int, ItemData> itemDataDict;

        // 아이템 데이터 로드 -> 생성자 -> 데이터 한 번 로드 후 메모리에 저장.
        private void LoadItemData()
        {
            try
            {
                List<ItemData> itemDataList = ResourceManager.Instance.LoadJsonData<ItemData>($"{ResourceManager.GAME_ROOT_DIR}/Data/ItemDataList.json");

                itemDataDict = new Dictionary<int, ItemData>();

                foreach (ItemData item in itemDataList)
                {
                    itemDataDict.Add(item.Id, item);
                }
            }
            catch
            {
                itemDataDict = new Dictionary<int, ItemData>();
                Console.WriteLine("아이템 데이터 로드 실패");
            }
        }

        void AddStartingItems()
        {
            AddItem(100, 3);
        }

        // 아이템 정보 받아오는 메서드
        public ItemData GetItemData (int itemID)
        {
            if (itemDataDict.ContainsKey(itemID))
            {
                return itemDataDict[itemID];
            }
            return null;
        }

        // 아이템 증가 메서드
        public void AddItem(int itemID, int count = 1)
        { 
            if (!itemDataDict.ContainsKey(itemID)) return;

            if (PlayerInventory.ContainsKey(itemID))
            {
                PlayerInventory[itemID] += count;
            }
            else
            {
                PlayerInventory.Add(itemID, count);
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

        // 포션 사용 메서드
        public bool UsePotion(int itemID)
        {
            // 소지하지 않았을 경우
            if (!HaveItem(itemID))
            {
                return false;
            }

            // 아이템 데이터 로드
            ItemData itemData = GetItemData(itemID);
            
            // 아이템 데이터가 없을 경우
            if (itemData == null)
            {
                return false;
            }

            // 소모품인지 확인
            if (itemData.Type != ItemType.Potion)
            {
                return false;
            }

            // 아이템 삭제
            if (RemoveItem(itemID, 1))
            {
                return true;
            }

            return false;
        }

    }
}
