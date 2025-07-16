using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Stat;

namespace TextRPG_Team3.Character
{
    public abstract class BaseCharacter
    {
        public string Name { get; set; }

        public Func<int, int> OnHit;
        public CharacterStatComponent Stat { get; set; }
        public bool IsAlive { get; set; }


        public BaseCharacter()
        {
            Name = "Chad";
            IsAlive = true;
        }

        // 시간남으면 IAttackable 인터페이스 해보기
        

    }
}
