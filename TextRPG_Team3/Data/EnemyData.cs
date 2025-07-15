using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace TextRPG_Team3.Data
{
    public class EnemyData
    {
        public int ID {  get; set; }
        public string Name { get; set; }
        public int HP { get; set; }
        public double Attack {  get; set; }
        public double Defense {  get; set; } 
    }
}
