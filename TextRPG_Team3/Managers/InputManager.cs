using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Utils;

namespace TextRPG_Team3.Managers
{
    internal class InputManager
    {
        static private InputManager instance;
        static public InputManager Instance { get { return instance; } }

        public InputManager()
        {
            if (instance == null)
            {
                instance = this;
            }
        }


        public int GetPlayerInput()
        {
            int ret;
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            int prevCursorTop = Console.CursorTop;

            while (true)
            {
                Console.Write(">> ");

                string inputStr = Console.ReadLine();
                if (!int.TryParse(inputStr, out ret))
                {
                    RenderHelper.DeleteConsoleLine(Console.CursorTop - prevCursorTop);
                }
                else
                {
                    break;
                }
            }

            return ret;
        }
    }
}
