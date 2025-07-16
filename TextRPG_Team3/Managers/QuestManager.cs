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

        public Dictionary<int, QuestData> QuestDB;

        public Dictionary<int, QuestData> GetQuestDB()
        {
            if (QuestDB == null)
            {
                List<QuestData> questList = ResourceManager.Instance.LoadJsonData<QuestData>($"{ResourceManager.GAME_ROOT_DIR}/Data/QuestDataList.json");

                QuestDB = new Dictionary<int, QuestData>();

                foreach (QuestData questData in questList)
                {
                    if (questData == null) continue;

                    QuestDB.Add(questData.ID, questData);
                }
            }
            return QuestDB;
        }

        public QuestData GetQuestData(int ID)
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
    }
}
