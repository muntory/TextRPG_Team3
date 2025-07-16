using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team3.Data
{
    public class EquipItemQuest : IQuest
    {
        public int GoalItemID { get; set; }
        private bool isEquipped;
        public EquipItemQuest(int ItemID)
        {
            GoalItemID = ItemID;
        }

        public void OnItemEquipped(int ItemID)
        {
            if (ItemID == GoalItemID)
            {
                isEquipped = true;
            }
        }

        public bool isCompleted => isEquipped;
    }
}
