using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team3.Managers
{
    internal class InputManager
    {
        static private InputManager instance = new InputManager();
        static public InputManager Instance { get { return instance; } }

        int menuMin = 0;
        int menuMax = 0;
        private void SetMinMax()
        {
            menuMin = SceneManager.Instance.CurrentScene.MenuMin;
            menuMax = SceneManager.Instance.CurrentScene.MenuMax;
        }
        public int GetMenuNumber()
        {
            SetMinMax();
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            while (true)
            {
                Console.WriteLine(">>");
                string inputStr = Console.ReadLine();
                if (!int.TryParse(inputStr, out int result))
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
                else
                {
                    if (result >= menuMin && result <= menuMax)
                    {
                        return result;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }
                }
            }
        }
    }
}
