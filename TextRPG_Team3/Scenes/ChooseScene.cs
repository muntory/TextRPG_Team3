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
            RenderHelper.Write("1. 파이리 ", ConsoleColor.Red);
            RenderHelper.Write("2. 꼬부기 ", ConsoleColor.Cyan);
            RenderHelper.Write("3. 이상해씨 ", ConsoleColor.Green);
            Console.WriteLine();

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
            
            PlayerCharacter player = new PlayerCharacter();
            PlayerStatComponent playerStat = player.Stat as PlayerStatComponent;

            CharacterJob characterJob = jobdata[input - 1];
            player.Name = name;
            player.RootClass = characterJob.JobName;
            playerStat.BaseAttack = characterJob.JobAtk;
            playerStat.BaseDefense = characterJob.JobDef;
            playerStat.MaxHealth = characterJob.JobHP;
            playerStat.Health = playerStat.MaxHealth;
            playerStat.MaxMP = characterJob.JobMP;
            playerStat.MP = playerStat.MaxMP;
            playerStat.CriticalRate = characterJob.CriticalRate;
            playerStat.AccuracyRate = characterJob.AccuracyRate;
            playerStat.CriticalDamageRate = characterJob.CriticalDamageRate;
            
            foreach (int skillId in characterJob.BaseSkillSet)
            {
                player.SkillList.Add(ResourceManager.Instance.GetSkillData(skillId));
            }
            
            GameManager.Instance.Player = player;
            SaveAndLoad load = new SaveAndLoad();
            load.Load();
            SceneManager.Instance.CurrentScene = new IntroScene();
        }
    }
}
