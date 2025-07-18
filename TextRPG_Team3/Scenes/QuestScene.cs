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
            RenderHelper.WriteLine("Quest!!", ConsoleColor.DarkYellow);
            Console.WriteLine();
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
            foreach (Quest quest in QuestManager.Instance.QuestDB.Values)
            {
                string clearStr = "";
                
                if (quest.IsCleared)
                {
                    clearStr = "[Cleared!]";
                }
                else if (quest.IsCompleted && quest.IsAccepted)
                {
                    clearStr = "[보상 획득 가능!]";
                }
                string temp = $"{quest.ID}. {quest.QuestName}";
                if (!quest.IsCleared)
                {
                    RenderHelper.Write($"{temp}",ConsoleColor.White);
                    RenderHelper.WriteLine($" {clearStr}", ConsoleColor.Green);
                }
                else
                {
                    temp += $" {clearStr}";
                    RenderHelper.WriteLine(temp, ConsoleColor.DarkGray);
                }
            }
            Console.WriteLine();
            RenderHelper.WriteLine("0. 나가기",ConsoleColor.White);
            Console.WriteLine();
        }
        private void RenderQuest(int index)
        {
            Quest quest = QuestManager.Instance.GetQuestData(index);

            RenderHelper.WriteLine($"{quest.QuestName}", ConsoleColor.Green);
            Console.WriteLine();
            RenderHelper.WriteLine($"{quest.QuestDescription}", ConsoleColor.White);
            Console.WriteLine();
            if (quest.Goal is KillEnemyQuest killQuest)
            {
                RenderHelper.Write($"- {quest.GoalData.GoalEnemyTier}티어 몬스터 ", ConsoleColor.Yellow);
                RenderHelper.Write($"{killQuest.GoalAmount}", ConsoleColor.Yellow);
                RenderHelper.Write($"마리 쓰러뜨리기! ({killQuest.CurrentAmount}/{killQuest.GoalAmount})\n", ConsoleColor.Yellow);
            }
            else if (quest.Goal is EquipItemQuest equipQuest)
            {
                RenderHelper.WriteLine($"- {ItemManager.Instance.GetItemData(equipQuest.GoalItemID).Name} 장착", ConsoleColor.Yellow);
            }
            else if(quest.Goal is LevelUpQuest levelQuest)
            {
                RenderHelper.Write($"- 레벨{levelQuest.GoalLevel} 달성하기! ", ConsoleColor.Yellow);
                RenderHelper.Write($"{GameManager.Instance.Player.Stat.Level}/{levelQuest.GoalLevel}\n", ConsoleColor.Yellow);
            }

            Console.WriteLine();
            RenderHelper.WriteLine("- 보상",ConsoleColor.DarkYellow);
            if(quest.ItemRewardID != -1)
            {
                RenderHelper.WriteLine($"  {ItemManager.Instance.GetItemData(quest.ItemRewardID).Name} x {quest.ItemAmount}", ConsoleColor.DarkYellow);
            }
            if (quest.GoldReward > 0)
            {
                RenderHelper.WriteLine($"  {quest.GoldReward} G", ConsoleColor.DarkYellow);
            }
            Console.WriteLine();

            if (!quest.IsAccepted)
            {
                RenderHelper.WriteLine("1. 수락",ConsoleColor.White);
                RenderHelper.WriteLine("2. 거절", ConsoleColor.White);
                Console.WriteLine();
            }
            else
            {
                RenderHelper.WriteLine("이미 수락한 퀘스트입니다.", ConsoleColor.Red);
                Console.WriteLine();
                if (quest.IsCompleted)
                {
                    RenderHelper.WriteLine("1. 보상 받기", ConsoleColor.White);
                }
                RenderHelper.WriteLine("0. 나가기", ConsoleColor.White);
                Console.WriteLine();
            }
        }
        public override void SelectMenu(int input)
        {
            if (index == 0 && 0 < input && input <= QuestManager.Instance.QuestDB.Count)
            {
                if (QuestManager.Instance.QuestDB[input].IsCleared)
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
                    else if (index != 0 && QuestManager.Instance.QuestDB[index].IsAccepted == true)
                    {
                        index = 0;
                    }
                    else
                    {
                        msg = "잘못된 입력입니다.";
                    }
                    break;
                case Enums.QuestMenuE.Accept:
                    if (index != 0 && !QuestManager.Instance.QuestDB[index].IsAccepted)
                    {
                        QuestManager.Instance.ActivateQuest(index);
                        index = 0;
                    }
                    else if (index != 0 && QuestManager.Instance.QuestDB[index].IsAccepted && QuestManager.Instance.QuestDB[index].IsCompleted)
                    {
                        QuestManager.Instance.QuestReward(index);
                        QuestManager.Instance.QuestDB[index].IsCleared = true;
                        QuestManager.Instance.ActiveQuests.Remove(QuestManager.Instance.QuestDB[index]);
                        index = 0;
                    }
                    else
                    {
                        msg = "잘못된 입력입니다.";
                    }
                    break;
                case Enums.QuestMenuE.Refuse:
                    if (index != 0 && !QuestManager.Instance.QuestDB[index].IsAccepted)
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
