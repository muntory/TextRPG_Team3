using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Character;
using TextRPG_Team3.Data;
using TextRPG_Team3.Managers;
using TextRPG_Team3.Stat;
using TextRPG_Team3.Utils;

namespace TextRPG_Team3.Scenes
{
    internal class ChooseScene: BaseScene
    {
        public string name;

        public override void Render()
        {
            base.Render();

            Console.WriteLine("닉네임을 설정해주세요.");
            name = Console.ReadLine();

            Console.WriteLine("직업을 선택해주세요.");
            Console.WriteLine("1. 전사 2. 마법사 3. 암살자");

        }

        public override void SelectMenu (int input)
        {
            List<CharacterJob> jobdata = ResourceManager.Instance.LoadJsonData<CharacterJob>($"{ResourceManager.GAME_ROOT_DIR}/Data/CharacterJob.json");

            if (!(0 < input && input <= jobdata.Count))
            {
                do
                {
                    RenderHelper.DeleteConsoleLine(2);
                    input = InputManager.Instance.GetPlayerInput();
                }
                while (!(0 < input && input <= jobdata.Count));
            }
            
            Character.PlayerCharacter player = new Character.PlayerCharacter();
            CharacterJob characterJob = jobdata[input - 1];
            player.Name = name;
            player.RootClass = characterJob.JobName;
            player.Stat.BaseAttack = characterJob.JobAtk;
            player.Stat.BaseDefense = characterJob.JobDef;
            player.Stat.MaxHealth = characterJob.JobHP;
            player.Stat.Health = player.Stat.MaxHealth;
            
            foreach (int skillId in characterJob.BaseSkillSet)
            {
                player.SkillList.Add(ResourceManager.Instance.GetSkillData(skillId));
            }

            Managers.GameManager.Instance.Player = player;
            SceneManager.Instance.CurrentScene = new IntroScene();
        }
    }
}
