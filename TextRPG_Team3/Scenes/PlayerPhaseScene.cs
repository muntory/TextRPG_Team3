using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Character;
using TextRPG_Team3.Managers;

namespace TextRPG_Team3.Scenes
{
    public class PlayerPhaseScene : BaseScene
    {
        List<EnemyCharacter> enemyCharacters;
        public override void Render()
        {
            base.Render();

            Console.WriteLine("플레이어 페이즈 씬입니다.");
            Console.WriteLine();

            
        }

        public override void SelectMenu(int input)
        {
            
        }

        public PlayerPhaseScene()
        {
            enemyCharacters = new List<EnemyCharacter>();
            enemyCharacters.Add(new EnemyCharacter());
        }
    }
}
