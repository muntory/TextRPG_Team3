using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Managers;

namespace TextRPG_Team3.Character
{
    public class EnemyCharacter : BaseCharacter
    {
        private bool isAlive;
        public EnemyCharacter() : base()
        {
            isAlive = true;
            CharacterStat.OnHpZero += Die;
        }

        // enemy Attack 로직 구현하기
        public void Attack(BaseCharacter target)
        {
            target.OnHit?.Invoke((int)CharacterStat.FinalAttack);
        }


        public void Die()
        {
            isAlive = false;

            // 에너미 사망 로직
            // 1. 플레이어 한테 경험치 주기
        }
        // HitReaction 로직 구현하기 (공격 받았을때 처리)

    }
}
