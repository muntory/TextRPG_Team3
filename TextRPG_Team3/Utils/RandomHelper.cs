using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team3.Utils
{
    public static class RandomHelper
    {
        public static bool ProcChance(double rate)
        {
            return Random.Shared.NextDouble() < rate;
        }
    }
}
