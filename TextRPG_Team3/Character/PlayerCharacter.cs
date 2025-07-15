using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team3.Character
{
    public class PlayerCharacter : BaseCharacter
    {
        public int Gold { get; set; }

        public PlayerCharacter() : base()
        {
            Gold = 1500;
        }

        // Attack 로직 구현 하기

        // HitReaction 로직 구현하기 (공격 받았을때 처리)
    }
}
