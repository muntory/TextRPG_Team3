using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Character;
using TextRPG_Team3.Data;
using TextRPG_Team3.Managers;
using static Enums;

namespace TextRPG_Team3.Scenes
{
    internal class ChooseScene: BaseScene
    {
        public string name = "";
        public bool Jobool = false;
        public static string GAME_ROOT_DIR = $"{AppDomain.CurrentDomain.BaseDirectory}/../../..";
        List<BaseCharacter> currentJob;

        public override void Render()
        {
            base.Render();
            Console.WriteLine("닉네임을 설정해주세요. ");
            name = Console.ReadLine();
            Console.WriteLine("직업을 선택해주세요.");
            Console.WriteLine("1. 전사, 2. 마법사, 3. 암살자");
        }

        public override void SelectMenu (int input)
        {
            currentJob = new List<BaseCharacter>();
            Enums.Job selectedNumber = (Enums.Job)input;
            List<CharacterJob> jobdata = ResourceManager.Instance.LoadJsonData<CharacterJob>($"{GAME_ROOT_DIR}/Data/CharacterJob.json");
            switch (selectedNumber)
            {
                case Enums.Job.Warrior:
                    CharacterJob characterjob = new CharacterJob();
                    break;

            }            
        }
        void Jobselect()
        {
            
            
        }
    }
}
