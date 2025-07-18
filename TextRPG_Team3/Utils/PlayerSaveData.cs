using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using TextRPG_Team3.Character;
using TextRPG_Team3.Data;
using TextRPG_Team3.Managers;
using TextRPG_Team3.Scenes;
using TextRPG_Team3.Stat;

namespace TextRPG_Team3.Utils
{
    public class PlayerSaveData
    {
        public string PlayerName { get; set; } 
        public int Level { get; set; }
        public int Gold { get; set; }
        public double Exp { get; set; }
        public int MP { get; set; }
        public int CurrentStage { get; set; }
        public int Health { get; set; }
        public int JobID {  get; set; }

        public PlayerSaveData()
        {
            PlayerStatComponent playerStat = GameManager.Instance.Player.Stat as PlayerStatComponent;
            PlayerName = GameManager.Instance.Player.Name;
            Level = GameManager.Instance.Player.Stat.Level;
            Gold = GameManager.Instance.Player.Gold;
            Exp = GameManager.Instance.Player.Stat.exp;
            MP = playerStat.MP;
            CurrentStage = GameManager.CurrentStage;
        }
    }

    public class ItemSaveData
    {
        public int ItemID { get; set; }
        public int ItemNum { get; set; }
        public bool IsEquipped { get; set; }
        public ItemSaveData(int itemID , int itemNum, bool isEquipped)
        {
            ItemID = itemID;
            ItemNum = itemNum;
            IsEquipped = isEquipped;
        }
    }

    public class QuestSaveData
    {
        public int QuestID { get; set; }
        public bool IsCleared {  get; set; }
        public bool IsAccepted {  get; set; }
        public int CurrentAmount { get; set; }

        public QuestSaveData(int questID, bool isCleared, bool isAccepted, int currentAmount)
        {
            QuestID = questID;
            IsCleared = isCleared;
            IsAccepted = isAccepted;
            CurrentAmount = currentAmount;
        }
    }
    
    public class SaveAndLoad
    {
        string savePath = $"{AppDomain.CurrentDomain.BaseDirectory}/../../../Save/";
        public void Save()
        {
            PlayerSaveData playerData = new PlayerSaveData();
            List<ItemSaveData> itemData = new List<ItemSaveData>();
            List<QuestSaveData> questData = new List<QuestSaveData>();
            SaveQuest(questData);
            SaveItem(itemData);
            ResourceManager.Instance.SaveJsonData(savePath + "PlayerSave.json", playerData);
            ResourceManager.Instance.SaveJsonData(savePath + "ItemSave.json", itemData);
            ResourceManager.Instance.SaveJsonData(savePath + "QuestSave.json", questData);
        }
        public void SavePlayer(PlayerSaveData playerData)
        {
            PlayerStatComponent playerStat = GameManager.Instance.Player.Stat as PlayerStatComponent;
            playerData.PlayerName = GameManager.Instance.Player.Name;
            playerData.Level = GameManager.Instance.Player.Stat.Level;
            playerData.Gold = GameManager.Instance.Player.Gold;
            playerData.Exp = playerStat.Exp;
            playerData.MP = playerStat.MP;
            playerData.CurrentStage = GameManager.CurrentStage;
            playerData.Health = playerStat.Health;
            if(GameManager.Instance.Player.RootClass == "?뚯씠由?)
            {
                playerData.JobID = 1;
            }
            else if (GameManager.Instance.Player.RootClass == "瑗щ?湲?)
            {
                playerData.JobID = 2;
            }
            else if (GameManager.Instance.Player.RootClass == "?댁긽?댁뵪")
            {
                playerData.JobID = 3;
            }
        }
        public void SaveQuest(List<QuestSaveData> questData)
        {
            for (int i = 1; i <= QuestManager.Instance.QuestDB.Count; i++)
            {
                int questID = i;
                bool isCleared = QuestManager.Instance.QuestDB[i].IsCleared;
                bool isAccepted = QuestManager.Instance.QuestDB[i].IsAccepted;
                int currentAmount;

                if (QuestManager.Instance.QuestDB[i].Goal is KillEnemyQuest killQuest)
                {
                    currentAmount = killQuest.CurrentAmount;
                }
                else
                {
                    currentAmount = -1;
                }

                QuestSaveData quest = new QuestSaveData(questID, isCleared, isAccepted, currentAmount);
                questData.Add(quest);
            }
        }
        public void SaveItem(List<ItemSaveData> itemData)
        {
            List<int> ID =ItemManager.Instance.AllHaveItemIDs();

           foreach(int i in ID)
            {
                int amount = ItemManager.Instance.PlayerInventory[i];
                bool isEquipped = ItemManager.Instance.GetItemData(i).IsEquipped;
                ItemSaveData item = new ItemSaveData(i, amount, isEquipped);
                itemData.Add(item);
            }
        }

        public void Load()
        {
            LoadPlayer();
            LoadItem();
            LoadQuest();
        }
        private void LoadPlayer()
        {
            if (!File.Exists(savePath + "PlayerSave.json"))
            {

            }
            else
            {
                string jsonPlayer = File.ReadAllText(savePath + "PlayerSave.json");
                PlayerSaveData playerData = JsonSerializer.Deserialize<PlayerSaveData>(jsonPlayer);
                ApplyPlayerData(playerData);
            }
        }
        private void LoadItem()
        {
            if (!File.Exists(savePath + "ItemSave.json"))
            {

            }
            else
            {
                List<ItemSaveData> itemData = ResourceManager.Instance.LoadJsonData<ItemSaveData>(savePath + "ItemSave.json");
                ApplyItemData(itemData);
            }
        }
        private void LoadQuest()
        {
            if (!File.Exists(savePath + "QuestSave.json"))
            {

            }
            else
            {
                List<QuestSaveData> questData = ResourceManager.Instance.LoadJsonData<QuestSaveData>(savePath + "QuestSave.json");
                ApplyQuestData(questData);
            }
        }
        private void ApplyPlayerData(PlayerSaveData playerData)
        {
            List<CharacterJob> jobdata = ResourceManager.Instance.LoadJsonData<CharacterJob>($"{ResourceManager.GAME_ROOT_DIR}/Data/CharacterJob.json");

            PlayerCharacter player = new PlayerCharacter();
            PlayerStatComponent playerStat = player.Stat as PlayerStatComponent;

            CharacterJob characterJob = jobdata[playerData.JobID-1];
            
            player.RootClass = characterJob.JobName;

            playerStat.BaseAttack = characterJob.JobAtk + ((playerData.Level - 1) * 0.5f);
            playerStat.BaseDefense = characterJob.JobDef + ((playerData.Level - 1));
            playerStat.MaxHealth = characterJob.JobHP;
            playerStat.Health = playerData.Health;
            playerStat.MaxMP = characterJob.JobMP;
            playerStat.MP = playerData.MP;
            playerStat.CriticalRate = characterJob.CriticalRate;
            playerStat.AccuracyRate = characterJob.AccuracyRate;
            playerStat.CriticalDamageRate = characterJob.CriticalDamageRate;
            playerStat.Level = playerData.Level;
            player.Name = playerData.PlayerName;
            playerStat.Exp = playerData.Exp;
            foreach (int skillId in characterJob.BaseSkillSet)
            {
                player.SkillList.Add(ResourceManager.Instance.GetSkillData(skillId));
            }

            GameManager.Instance.Player = player;
            GameManager.Instance.Player.Gold = playerData.Gold;
            GameManager.CurrentStage = playerData.CurrentStage;
        }
        private void ApplyItemData(List<ItemSaveData> itemData)
        {
            foreach (ItemSaveData data in itemData)
            {
                ItemManager.Instance.AddItem(data.ItemID, data.ItemNum);
                if(data.IsEquipped == true)
                {
                    ItemManager.Instance.EquipItem(data.ItemID);
                }
            }
        }
        private void ApplyQuestData(List<QuestSaveData> questData)
        {
            
            foreach(QuestSaveData quest in questData)
            {
                QuestManager.Instance.QuestDB[quest.QuestID].IsCleared = quest.IsCleared;
                QuestManager.Instance.QuestDB[quest.QuestID].IsAccepted = quest.IsAccepted;
                if(quest.CurrentAmount != -1)
                {
                    if (QuestManager.Instance.QuestDB[quest.QuestID].Goal is KillEnemyQuest killQuest)
                    {
                        killQuest.CurrentAmount = quest.CurrentAmount;
                    }
                }
            }
        }
    }

}