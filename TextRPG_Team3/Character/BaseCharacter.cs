using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team3.Character
{
    public class BaseCharacter
    {
        public string Name { get; set; }
        public CharacterStatComponent CharacterStat { get; set; }

        public Action<int> OnHit;

        public BaseCharacter()
        {
            Name = "Chad";
            CharacterStat = new CharacterStatComponent();
            OnHit += TakeDamage;

        }

        private void TakeDamage(int inDamage)
        {
            CharacterStat.Health -= inDamage;
        }
    }
}
