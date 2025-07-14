using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team3.Others
{
    internal class GetNumber
    {
        int result = 0;
        public int GetMenuNumber(int min, int max)
        {
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            while (true)
            {
                Console.WriteLine(">>");
                string inputStr = Console.ReadLine();
                if(!int.TryParse(inputStr, out result))
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
                else
                {
                    if(result >= min && result <= max)
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
