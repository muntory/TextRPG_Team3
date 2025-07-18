using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Managers;

namespace TextRPG_Team3.Utils
{
    public static class RenderHelper
    {
        public static void WriteLine(string str = "", ConsoleColor color = ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(str);
            Console.ResetColor();
        }

        public static void Write(string str, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
            Console.Write(str);
            Console.ResetColor();
        }

        public static ConsoleColor GetPlayerColor()
        {
            ConsoleColor color = ConsoleColor.Gray;

            if (GameManager.Instance.Player.RootClass == "파이리")
            {
                color = ConsoleColor.Red;
            }
            if (GameManager.Instance.Player.RootClass == "꼬부기")
            {
                color = ConsoleColor.Cyan;
            }
            if (GameManager.Instance.Player.RootClass == "이상해씨")
            {
                color = ConsoleColor.Green;
            }

            return color;
        }
        public static ConsoleColor GetStatColor(Enums.StatType type)
        {
            ConsoleColor color;
            switch (type)
            {
                case Enums.StatType.Level:
                    color = ConsoleColor.White;
                    break;
                case Enums.StatType.Attack:
                    color = ConsoleColor.Yellow;
                    break;
                case Enums.StatType.Defense:
                    color = ConsoleColor.Cyan;
                    break;
                case Enums.StatType.Health:
                    color = ConsoleColor.Red;
                    break;
                default:
                    color = ConsoleColor.Gray;
                    break;
            }
            return color;
        }
        public static void DeleteConsoleLine(int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop);
            }
        }


        /// <summary>
        /// 문자열의 길이를 <paramref name="totalWidth"/>만큼 설정하고 부족한 길이만큼 <paramref name="str"/>의 오른쪽에 빈칸으로 패딩을 설정하여 반환
        /// </summary>
        /// <param name="str"></param>
        /// <param name="totalWidth"></param>
        /// <returns></returns>
        public static string AlignLeftWithPadding(string str, int totalWidth)
        {
            int width = 0;

            foreach (char c in str)
            {
                // 대부분의 한글은 2칸 차지함
                width += EastAsianWidth.GetWidth(c);
            }

            int padding = Math.Max(0, totalWidth - width);

            return $"{str}{new string(' ', padding)}";
        }


        /// <summary>
        /// 문자열의 길이를 <paramref name="totalWidth"/>만큼 설정하고 부족한 길이만큼 <paramref name="str"/>의 왼쪽에 빈칸으로 패딩을 설정하여 반환
        /// </summary>
        /// <param name="str"></param>
        /// <param name="totalWidth"></param>
        /// <returns></returns>
        public static string AlignRightWithPadding(string str, int totalWidth)
        {
            int width = 0;

            foreach (char c in str)
            {
                // 대부분의 한글은 2칸 차지함
                width += EastAsianWidth.GetWidth(c);
            }

            int padding = Math.Max(0, totalWidth - width);

            return $"{new string(' ', padding)}{str}";

        }

        public static string AlignCenterWithPadding(string str, int totalWidth)
        {
            int width = 0;

            foreach (char c in str)
            {
                // 대부분의 한글은 2칸 차지함
                width += EastAsianWidth.GetWidth(c);
            }

            int padding = Math.Max(0, totalWidth - width);
            int left = padding / 2;
            int right = padding - left;

            return $"{new string(' ', left)}{str}{new string(' ', right)}";

        }


        public static class EastAsianWidth
        {
            public static int GetWidth(char c)
            {
                var cat = CharUnicodeInfo.GetUnicodeCategory(c);
                // 한글, 한자, 일본어는 대부분 너비 2
                if (cat == UnicodeCategory.OtherLetter)
                    return 2;

                return 1;
            }
        }
    }
}
