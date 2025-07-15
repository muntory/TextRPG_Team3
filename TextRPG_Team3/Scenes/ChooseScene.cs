using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team3.Scenes
{
    internal class ChooseScene: BaseScene
    {
        public string name = "";
        public int Job = 0;
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
            Job = int.Parse(Console.ReadLine());
            switch (Job)
            {
                case 1:
                    break;
                        
            }
        }
    }
}
