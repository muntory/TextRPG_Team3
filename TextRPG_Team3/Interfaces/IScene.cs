using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team3.Interfaces
{
    public interface IScene
    {
        void Render(ref int menuMin, ref int menuMax);
        void SelectMenu(int num);
    }
}
