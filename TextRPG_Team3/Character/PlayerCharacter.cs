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
            CharacterStat.OnHpZero += Die;
        }

        // Attack 로직 구현 하기
        public void Attack(BaseCharacter target)
        {
            double damageModifier = 1.0 + (Random.Shared.NextDouble() * 20.0 - 10.0) * 0.01;
            double inDamage = CharacterStat.FinalAttack * damageModifier;
            inDamage = Math.Ceiling(inDamage);

            target.OnHit?.Invoke((int)inDamage);
        }

        public void Die()
        {
            // 플레이어 사망 로직
        }

        // HitReaction 로직 구현하기 (공격 받았을때 처리)
    }
}
