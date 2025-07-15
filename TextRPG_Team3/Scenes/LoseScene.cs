using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Character;
using TextRPG_Team3.Managers;

namespace TextRPG_Team3.Scenes
{
    internal class LoseScene
    {
        public void CheckPlayerLose()
        {
            if (GameManager.Instance.Player.PlayerStat.Health == 0)
            {
                LoseScene loseScene = new LoseScene();
               loseScene.ShowLoseScene(GameManager.Instance.Player);
            }
        }
          
        
        public void ShowLoseScene(PlayerCharacter Player)
        {
            Console.Clear();
            Console.WriteLine("============== Battle Result ==============");
            Console.WriteLine("               [   GAME OVER   ]           \n");
            Console.WriteLine("패배! 당신의 HP가 0이 되어 전투에서 졌습니다.");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"플레이어: {Player.Name}");
            Console.WriteLine($"레벨: {Player.PlayerStat.Level}");
            Console.WriteLine($"HP: 0 / {Player.PlayerStat.MaxHealth}");
            Console.WriteLine($"보유 골드: {Player.Gold} G");
            Console.WriteLine("------------------------------------------\n");
            Console.WriteLine("0. 타이틀로 돌아가기");
            Console.WriteLine("==========================================");

        }
    }
}
