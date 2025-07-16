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
            foreach(QuestData quest in QuestManager.Instance.QuestDB.Values)
            {
                string clearStr = quest.isCleared ? " Cleared!" : "";
                Console.WriteLine($"{quest.ID}. {quest.QuestName} {clearStr}");
            }
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
        }
        private void RenderQuest(int index)
        {
            Console.WriteLine($"{QuestManager.Instance.QuestDB[index].QuestName}");
            Console.WriteLine();
            Console.WriteLine($"{QuestManager.Instance.QuestDB[index].QuestDescription}");
            Console.WriteLine();
            Console.WriteLine("- 미니언 5마리 처치(0/5)");//몬스터랑 연결해야됨.
            Console.WriteLine();
            Console.WriteLine("- 보상");
            Console.WriteLine($"  {QuestManager.Instance.QuestDB[index].GoldReward} G");
            Console.WriteLine();

            if (!QuestManager.Instance.QuestDB[index].isAccepted)
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
                if (QuestManager.Instance.QuestDB[input].isCleared)
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
                        QuestManager.Instance.QuestDB[index].isAccepted = true;
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
