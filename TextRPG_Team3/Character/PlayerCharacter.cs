using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Stat;
using TextRPG_Team3.Managers;
using TextRPG_Team3.Scenes;
using TextRPG_Team3.Data;
using TextRPG_Team3.Utils;

namespace TextRPG_Team3.Character
{
    public class PlayerCharacter : BaseCharacter
    {
        public int Gold { get; set; }
        public string RootClass { get; set; }

        public List<SkillData> SkillList;
        public PlayerCharacter() : base()
        {
            Gold = 1500;
            RootClass = "전사";
            Stat = new PlayerStatComponent();
            SkillList = new List<SkillData>();
            OnHit += Stat.TakeDamage;
            Stat.OnHpZero += Die;
        }

        // Attack 로직 구현 하기
        /// <summary>
        /// 크리티컬공격 : 1, 공격 실패(명중 실패) : -1, 그냥 공격 : 0 리턴
        /// </summary>
        /// <param name="target"></param>
        public override int Attack(BaseCharacter target)
        {
            int ret = -2;
            if (!IsAlive)
            {
                return ret;
            }

            PlayerStatComponent playerStat = (PlayerStatComponent)Stat;

            // 공격 실패
            if (!RandomHelper.ProcChance(playerStat.AccuracyRate))
            {
                ret = -1;
                return ret;
            }

            double damageModifier = 1.0 + (Random.Shared.NextDouble() * 20.0 - 10.0) * 0.01;
            double inDamage = Stat.FinalAttack * damageModifier;
            double criticalRate = playerStat.CriticalRate;
            if (RandomHelper.ProcChance(playerStat.CriticalRate))
            {
                ret = 1;
                inDamage *= playerStat.CriticalDamageRate;
            }
            inDamage = Math.Ceiling(inDamage);

            ret = 0;
            target.OnHit?.Invoke((int)inDamage);

            return ret;
        }

        public int ActiveSkill(BaseCharacter target, SkillData skillData)
        {
            if (skillData == null) return -1;

            PlayerStatComponent playerStat = (PlayerStatComponent)Stat;
            if (playerStat == null) return -1;

            double inDamage = Stat.FinalAttack * skillData.Multiplier;

            int ret = 0;
            if (RandomHelper.ProcChance(playerStat.CriticalRate))
            {
                ret = 1;
                inDamage *= playerStat.CriticalDamageRate;
            }
            inDamage = Math.Ceiling(inDamage);

            target.OnHit?.Invoke((int)inDamage);
            return ret;
        }

        public void Die()
        {
            if (IsAlive)
            {
                IsAlive = false;

            }
            // 플레이어 사망 로직
        }

        // HitReaction 로직 구현하기 (공격 받았을때 처리)


    }
}
