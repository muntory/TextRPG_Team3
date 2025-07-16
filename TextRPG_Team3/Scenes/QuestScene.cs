using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TextRPG_Team3.Data;
using TextRPG_Team3.Managers;
using TextRPG_Team3.Utils;

namespace TextRPG_Team3.Scenes
{
    internal class QuestScene : BaseScene
    {
        int index = 0;
        public override void Render()
        {
            base.Render();
            Console.WriteLine("Quest!!");
            Console.WriteLine();

            switch (index)
            {
                case 0:
                    RenderQuestIntro();
                    break;
                default:
                    RenderQuest(index);
                    break;
            }
            PrintMsg();
        }
        private void RenderQuestIntro()
        {
            QuestManager.Instance.GetQuestDB();
            int questCount = 1;
            foreach(Quest quest in QuestManager.Instance.QuestDB.Values)
            {
                string clearStr = quest.IsCompleted ? " Cleared!" : "";
                Console.WriteLine($"{questCount}. {quest.QuestName} {clearStr}");
                questCount++;
            }
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
        }
        private void RenderQuest(int index)
        {
            Quest quest = QuestManager.Instance.QuestDB[index];
            Console.WriteLine($"{quest.QuestName}");
            Console.WriteLine();
            Console.WriteLine($"{quest.QuestDescription}");
            Console.WriteLine();
            if (quest.Goal is KillEnemyQuest killQuest)
            {
                Console.Write($"- {ResourceManager.Instance.GetEnemyData(quest.GoalData.GoalEnemyID).Name} ");
                Console.Write($"{killQuest.GoalAmount}마리 처치 ({killQuest.CurrentAmount}/{killQuest.GoalAmount})");
            }
            else if(quest.Goal is EquipItemQuest equipQuest)
            {
                Console.Write("장착 퀘스트 테스트입니다.");
            }

            Console.WriteLine();
            Console.WriteLine("- 보상");
            Console.WriteLine($"  {quest.GoldReward} G");
            Console.WriteLine();

            if (!quest.isAccepted)
            {
                Console.WriteLine("1. 수락");
                Console.WriteLine("2. 거절");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("이미 수락한 퀘스트입니다.");
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
            }
        }
        public override void SelectMenu(int input)
        {
            if (index == 0 && 0 < input && input <= QuestManager.Instance.QuestDB.Count)
            {
                if (QuestManager.Instance.QuestDB[input].IsCompleted)
                {
                    msg = "잘못된 입력입니다.";
                    return;
                }
                index = input;
                SceneManager.Instance.CurrentScene = this;
                return;
            }

            Enums.QuestMenuE questMenu = (Enums.QuestMenuE)input;

            switch (questMenu)
            {
                case Enums.QuestMenuE.Out:
                    if (index == 0)
                    {
                        SceneManager.Instance.CurrentScene = new IntroScene();
                    }
                    else if (index != 0 && QuestManager.Instance.QuestDB[index].isAccepted == true)
                    {
                        index = 0;
                    }
                    else
                    {
                        msg = "잘못된 입력입니다.";
                    }
                    break;
                case Enums.QuestMenuE.Accept:
                    if (index != 0 && !QuestManager.Instance.QuestDB[index].isAccepted)
                    {
                        QuestManager.Instance.ActivateQuest(index);
                        index = 0;
                    }
                    else
                    {
                        msg = "잘못된 입력입니다.";
                    }
                    break;
                case Enums.QuestMenuE.Refuse:
                    if (index != 0 && !QuestManager.Instance.QuestDB[index].isAccepted)
                    {
                        index = 0;
                    }
                    else
                    {
                        msg = "잘못된 입력입니다.";
                    }
                    break;
                default:
                    msg = "잘못된 입력입니다.";
                    break;
            }
        }
    }
}
