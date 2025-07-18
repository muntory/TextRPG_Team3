using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Managers;
using TextRPG_Team3.Stat;

namespace TextRPG_Team3.Utils
{
    public class PlayerSaveData
    {
        public string JobName {  get; set; }
        public int Level { get; set; }
        public int Gold { get; set; }
        public double Exp { get; set; }
        public int MP { get; set; }
        public int CurrentStage { get; set; }

        public PlayerSaveData()
        {
            PlayerStatComponent playerStat = GameManager.Instance.Player.Stat as PlayerStatComponent;
            JobName = GameManager.Instance.Player.RootClass;
            Level = GameManager.Instance.Player.Stat.Level;
            Gold = GameManager.Instance.Player.Gold;
            Exp = GameManager.Instance.Player.Stat.exp;
            MP = playerStat.MP;
            CurrentStage = GameManager.CurrentStage;
        }
    }

    public class ItemData
    {
        
    }
}