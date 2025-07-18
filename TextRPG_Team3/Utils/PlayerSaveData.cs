using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Data;
using TextRPG_Team3.Managers;
using TextRPG_Team3.Scenes;
using TextRPG_Team3.Stat;

namespace TextRPG_Team3.Utils
{
    public class PlayerSaveData
    {
        public string JobName {  get; set; }
        public int Level { get; set; }
        public int Gold { get; set; }
        public double Exp { get; set; }
        public int MP { get; set; }
        public int CurrentStage { get; set; }

        public PlayerSaveData()
        {
            PlayerStatComponent playerStat = GameManager.Instance.Player.Stat as PlayerStatComponent;
            JobName = GameManager.Instance.Player.RootClass;
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
        public void Save()
        {
            PlayerSaveData playerData = new PlayerSaveData();
            List<ItemSaveData> itemData = new List<ItemSaveData>();
            List<QuestSaveData> questData = new List<QuestSaveData>();
            SaveQuest(questData);
        }
        public void SaveQuest(List<QuestSaveData> questData)
        {
            for (int i = 1; i < QuestManager.Instance.QuestDB.Count; i++)
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
    }
}