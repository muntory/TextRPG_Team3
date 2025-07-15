using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team3.Character
{
    public class EnemyCharacter : BaseCharacter
    {
        public int ID { get; set; } //1부터 시작
        public string Name { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int HP { get; set; }
    }
}
