using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team3.Character
{
    public class CharacterStatComponent
    {
        // 캐릭터 스탯 타입 : 레벨, 공격력, 방어력, 체력
        public enum CharacterStatType
        {
            Level,
            Attack,
            Defense,
            Health,
        }

        public Action OnHpZero;

        // 레벨 선언 -> Private로
        private int level;

        // 프로퍼티 선언 -> level에 음수 값이 할당되지 않도록 하기 위함
        public int Level
        {
            get { return level; }
            set { level = Math.Max(1, value); }
        }

        // 공격력 선언 (기본, 변동, 최종)
        public double BaseAttack;
        public double ExtraAttack = 0.0;
        public double FinalAttack
        {
            get { return BaseAttack + ExtraAttack; }
        }

        // 방어력 선언 (기본, 변동, 최종)
        public double BaseDefense;
        public double ExtraDefense = 0.0;
        public double FinalDefense
        {
            get { return BaseDefense + ExtraDefense; }
        }

        // 체력 선언
        private int health;
        public int Health           // 체력 범위 한정
        {
            get { return health; }
            set
            {
                health = Math.Clamp(value, 0, 100);
                if (health == 0)
                {
                    OnHpZero?.Invoke();
                }
            }
        }

        public CharacterStatComponent()
        {
            Level = 1;
            BaseAttack = 10.0;
            BaseDefense = 5.0;
            Health = 100;
        }
    }
}
