using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Data;

namespace TextRPG_Team3.Managers
{
    internal class QuestManager
    {
        private static QuestManager instance;
        public static QuestManager Instance { get { return instance; } }

        public Dictionary<int, Quest> QuestDB;
        public List<Quest> ActiveQuests = new();

        public Dictionary<int, Quest> GetQuestDB()
        {
            if (QuestDB == null)
            {
                List<Quest> questList = ResourceManager.Instance.LoadJsonData<Quest>($"{ResourceManager.GAME_ROOT_DIR}/Data/QuestDataList.json");

                QuestDB = new Dictionary<int, Quest>();

                foreach (Quest quest in questList)
                {
                    if (quest == null) continue;
                    if (quest.QuestType == "Kill")
                    {
                        quest.Goal = new KillEnemyQuest(quest.GoalData.GoalEnemyID, quest.GoalData.GoalAmount);
                    }
                    else if (quest.QuestType == "Equip")
                    {
                        quest.Goal = new EquipItemQuest(quest.GoalData.GoalItemID);
                    }

                        QuestDB.Add(quest.ID, quest);
                }
            }
            return QuestDB;
        }

        public Quest GetQuestData(int ID)
        {
            if (QuestDB == null)
            {
                GetQuestDB();
            }

            return QuestDB[ID];
        }
        public QuestManager()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
        public void ActivateQuest(int ID)
        {
            QuestDB[ID].isAccepted = true;
            ActiveQuests.Add(QuestDB[ID]);
        }

        public void OnItemEquipped(int ID)
        {
            foreach(var quest in ActiveQuests)
            {
                if(quest.Goal is EquipItemQuest equipGoal)
                {
                    equipGoal.OnItemEquipped(ID);
                }
            }
        }

        public void OnEnemyKilled(int ID)
        {
            foreach(var quest in ActiveQuests)
            {
                if(quest.Goal is KillEnemyQuest killGoal)
                {
                    killGoal.OnEnemyKilled(ID);
                }
            }
        }
    }
}
