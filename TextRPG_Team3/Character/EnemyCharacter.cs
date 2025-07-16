using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Data;
using TextRPG_Team3.Managers;
using TextRPG_Team3.Stat;
using TextRPG_Team3.Scenes;

namespace TextRPG_Team3.Character
{
    public class EnemyCharacter : BaseCharacter
    {
        public EnemyCharacter() : base()
        {
            Stat = new CharacterStatComponent();
            OnHit += Stat.TakeDamage;
            Stat.OnHpZero += Die;
        }

        public EnemyCharacter(EnemyData enemyData) : this()
        {
            Name = enemyData.Name;
            Stat.MaxHealth = enemyData.HP;
            Stat.Health = Stat.MaxHealth;
            Stat.BaseAttack = enemyData.Attack;
            Stat.BaseDefense = enemyData.Defense;
        }

        // enemy Attack 로직 구현하기
        public void Attack(BaseCharacter target)
        {
            if (!IsAlive)
                return;
            target.OnHit?.Invoke((int)Stat.FinalAttack);
        }


        public void Die()
        {
            if (IsAlive)
            {
                IsAlive = false;
            }
            

            // 에너미 사망 로직
            // 1. 플레이어 한테 경험치 주기
        }
        // HitReaction 로직 구현하기 (공격 받았을때 처리)

    }
}
