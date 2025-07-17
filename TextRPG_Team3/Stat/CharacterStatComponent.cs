using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Managers;

namespace TextRPG_Team3.Stat
{
    public class CharacterStatComponent
    {
        // 캐릭터 스탯 타입 : 레벨, 공격력, 방어력, 체력
        

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
        public int MaxHealth;
        private int health = 1;
        public int Health           // 체력 범위 한정
        {
            get { return health; }
            set
            {
                health = Math.Clamp(value, 0, MaxHealth);
                if (Health == 0)
                {
                    OnHpZero?.Invoke();
                }
            }
        }

        private double Exp;
        public double exp
        {
            get { return Exp; }
            set
            {
                Exp = value;
            }
        }

        public void SetLevel(int level)
        {
            Level = level;

            MaxHealth += (int)(MaxHealth * (0.15 * (level - 1)));
            Health = MaxHealth;

            BaseAttack += BaseAttack * 0.05 * (level - 1);
            BaseDefense += BaseDefense * 0.04 * (level - 1);

        }


        public int TakeDamage(int inDamage)
        {
            int prevHealth = Health;
            Health -= inDamage;

            return Health - prevHealth;
        }


        public CharacterStatComponent()
        {
            Level = 1;
            BaseAttack = 10.0;
            BaseDefense = 5.0;
            MaxHealth = 100;
            Health = MaxHealth;
            exp = 0.0;
        }
    }
}
