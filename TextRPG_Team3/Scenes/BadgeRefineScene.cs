using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team3.Character;
using TextRPG_Team3.Data;
using TextRPG_Team3.Item;
using TextRPG_Team3.Managers;
using TextRPG_Team3.Stat;
using TextRPG_Team3.Utils;

namespace TextRPG_Team3.Scenes
{
    public class BadgeRefineScene : BaseScene
    {
        private Dictionary<int, List<BadgeRefineData>> EffectsByRarity;
        private Dictionary<int, BadgeRefineData> refineTable;
        private List<Badge> badgeList = GameManager.Instance.BadgeList;
        private Badge currentBadge = null;

        public BadgeRefineScene()
        {
            if (EffectsByRarity == null)
            {
                EffectsByRarity = new Dictionary<int, List<BadgeRefineData>>();
            }

            if (refineTable == null)
            {
                refineTable = new Dictionary<int, BadgeRefineData>();
            }
            List<BadgeRefineData> effectList = ResourceManager.Instance.LoadJsonData<BadgeRefineData>($"{ResourceManager.GAME_ROOT_DIR}/Data/BadgeRefineDataList.json");

            if (effectList != null)
            {
                foreach (BadgeRefineData badgeData in effectList)
                {
                    int rarity = badgeData.Rarity;
                    refineTable.Add(badgeData.ID, badgeData);

                    if (!EffectsByRarity.ContainsKey(rarity))
                    {
                        EffectsByRarity.Add(rarity, new List<BadgeRefineData>());
                    }

                    EffectsByRarity[rarity].Add(badgeData);

                }
            }

            
        }

        public override void Render()
        {
            base.Render();

            if (currentBadge == null)
            {
                RenderHelper.WriteLine("이곳에서 획득한 배지를 정제할 수 있지. 정제하면 놀라운 힘이 깃들 거야.", ConsoleColor.DarkYellow);
                Console.WriteLine();

                for (int i = 0; i < badgeList.Count; i++)
                {
                    string badgeName = badgeList[i].Name;
                    string badgeRarity = GetRarityStr(badgeList[i].Rarity);
                    string badgeEffectsStr = string.Empty;

                    RenderHelper.Write($"{i + 1} {badgeName} | ", ConsoleColor.White);
                    RenderHelper.Write(RenderHelper.AlignCenterWithPadding(badgeRarity, 8), GetRarityColor(badgeList[i].Rarity));
                    RenderHelper.Write(" | ", ConsoleColor.White);

                    if (badgeList[i].Effects != null)
                    {
                        for (int j = 0; j < 3; ++j)
                        {
                            RenderHelper.Write(RenderHelper.AlignCenterWithPadding(refineTable[badgeList[i].Effects[j]].Description, 20), GetRarityColor(refineTable[badgeList[i].Effects[j]].Rarity));
                            RenderHelper.Write(" | ", ConsoleColor.White);
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();

                PrintMsg();

                RenderHelper.WriteLine("0. 나가기");
            }
            else
            {

                RenderHelper.WriteLine($"{RenderHelper.AlignCenterWithPadding(currentBadge.Name, 40)}", ConsoleColor.White);
                Console.WriteLine();

                if (currentBadge.Effects != null)
                {
                    RenderHelper.WriteLine($"{RenderHelper.AlignCenterWithPadding($"{GetRarityStr(currentBadge.Rarity)}", 40)}", GetRarityColor(currentBadge.Rarity));
                    RenderHelper.WriteLine($"{RenderHelper.AlignCenterWithPadding($"{refineTable[currentBadge.Effects[0]].Description}", 40)}", GetRarityColor(refineTable[currentBadge.Effects[0]].Rarity));
                    RenderHelper.WriteLine($"{RenderHelper.AlignCenterWithPadding($"{refineTable[currentBadge.Effects[1]].Description}", 40)}", GetRarityColor(refineTable[currentBadge.Effects[1]].Rarity));
                    RenderHelper.WriteLine($"{RenderHelper.AlignCenterWithPadding($"{refineTable[currentBadge.Effects[2]].Description}", 40)}", GetRarityColor(refineTable[currentBadge.Effects[2]].Rarity));
                }
                Console.WriteLine();

                PrintMsg();

                RenderHelper.WriteLine("1. 계속 정제하기");
                RenderHelper.WriteLine("0. 나가기");

            }


        }

        private string GetRarityStr(int rarity)
        {
            string str = "레어";
            if (rarity == 1) str = "에픽";
            if (rarity == 2) str = "유니크";
            if (rarity == 3) str = "레전드리";
            return str;
        }
        private ConsoleColor GetRarityColor(int rarity)
        {
            ConsoleColor color = ConsoleColor.White;
            if (rarity == 1) color = ConsoleColor.Magenta;
            if (rarity == 2) color = ConsoleColor.Yellow;
            if (rarity == 3) color = ConsoleColor.DarkGreen;
            return color;
        }

        public override void SelectMenu(int input)
        {
            if (currentBadge == null)
            {
                if (0 < input && input <= badgeList.Count)
                {
                    // 정제
                    currentBadge = badgeList[input - 1];
                    RefineBadge(currentBadge);
                }
                else if (input == 0)
                {
                    SceneManager.Instance.CurrentScene = new IntroScene();
                }
                else
                {
                    msg = "잘못된 입력입니다.";
                }
            }
            else
            {
                if (input == 0)
                {
                    currentBadge = null;
                }
                else if (input == 1)
                {
                    RefineBadge(currentBadge);
                }
                else
                {
                    msg = "잘못된 입력입니다.";
                }
            }
        }

        private void RefineBadge(Badge badge)
        {
            
            // 만약 뱃지 효과가 있다면 효과 제거
            DeactiveEffect(badge);

            badge.Effects = new int[3];

            // 등급 업
            if (badge.Rarity == 0)
            {
                if (RandomHelper.ProcChance(0.06))
                    badge.Rarity++;
            }
            else if (badge.Rarity == 1)
            {
                if (RandomHelper.ProcChance(0.018))
                    badge.Rarity++;
            }
            else if (badge.Rarity == 2)
            {
                if (RandomHelper.ProcChance(0.003))
                    badge.Rarity++;
            }
            

            // 현재 뱃지의 등급기반 3줄 랜덤
            int firstRarity = badge.Rarity;
            int secondRarity;
            int thirdRarity;

            if (firstRarity == 0)
            {
                secondRarity = firstRarity;
                thirdRarity = firstRarity;
            }
            else
            {
                secondRarity = RandomHelper.ProcChance(0.1) ? firstRarity : firstRarity - 1;
                thirdRarity = RandomHelper.ProcChance(0.01) ? firstRarity : firstRarity - 1;
            }

            badge.Effects[0] = ProcCumulativeChance(EffectsByRarity[firstRarity]).ID;
            badge.Effects[1] = ProcCumulativeChance(EffectsByRarity[secondRarity]).ID;
            badge.Effects[2] = ProcCumulativeChance(EffectsByRarity[thirdRarity]).ID;


            // 뱃지 효과 반영
            ActiveEffect(badge);
        }

        private BadgeRefineData ProcCumulativeChance(List<BadgeRefineData> table)
        {
            double randomValue = Random.Shared.NextDouble();

            double cumulativeValue = 0.0;

            foreach (BadgeRefineData effectData in table)
            {
                cumulativeValue += effectData.Chance;
                if (randomValue < cumulativeValue)
                {
                    return effectData;
                }
            }
            return table.Last();
        }
        private void ActiveEffect(Badge badge)
        {
            PlayerStatComponent playerStat = GameManager.Instance.Player.Stat as PlayerStatComponent;

            foreach (int id in badge.Effects)
            {
                BadgeRefineData data = refineTable[id];
                if (data.IsPercent)
                {
                    switch (data.StatType)
                    {
                        case Enums.StatType.Attack:
                            playerStat.BaseAttack += playerStat.BaseAttack * data.Value;
                            break;
                        case Enums.StatType.Defense:
                            playerStat.BaseDefense += playerStat.BaseDefense * data.Value;
                            break;
                        case Enums.StatType.MP:
                            playerStat.MaxMP += (int)(playerStat.MaxMP * data.Value);
                            break;
                        case Enums.StatType.Health:
                            playerStat.MaxHealth += (int)(playerStat.MaxHealth * data.Value);
                            break;
                        case Enums.StatType.CriticalDamageRate:
                            playerStat.CriticalDamageRate += playerStat.CriticalDamageRate * data.Value;
                            break;
                        case Enums.StatType.CriticalRate:
                            playerStat.CriticalRate += playerStat.CriticalRate * data.Value;
                            break;
                        case Enums.StatType.ExpRate:
                            playerStat.ExpRate += playerStat.ExpRate * data.Value;
                            break;
                    }
                }
                else
                {
                    switch (data.StatType)
                    {
                        case Enums.StatType.Attack:
                            playerStat.BaseAttack += data.Value;
                            break;
                        case Enums.StatType.Defense:
                            playerStat.BaseDefense += data.Value;
                            break;
                        case Enums.StatType.MP:
                            playerStat.MaxMP += (int)data.Value;
                            break;
                        case Enums.StatType.Health:
                            playerStat.MaxHealth += (int)data.Value;
                            break;
                        case Enums.StatType.CriticalDamageRate:
                            playerStat.CriticalDamageRate += data.Value;
                            break;
                        case Enums.StatType.CriticalRate:
                            playerStat.CriticalRate += data.Value;
                            break;
                        case Enums.StatType.ExpRate:
                            playerStat.ExpRate += data.Value;
                            break;
                    }
                }


            }

        }

        private void DeactiveEffect(Badge badge)
        {
            PlayerStatComponent playerStat = GameManager.Instance.Player.Stat as PlayerStatComponent;

            if (badge.Effects == null)
            {
                return;
            }

            foreach (int id in badge.Effects)
            {
                BadgeRefineData data = refineTable[id];
                if (data.IsPercent)
                {
                    switch (data.StatType)
                    {
                        case Enums.StatType.Attack:
                            playerStat.BaseAttack -= playerStat.BaseAttack * data.Value;
                            break;
                        case Enums.StatType.Defense:
                            playerStat.BaseDefense -= playerStat.BaseDefense * data.Value;
                            break;
                        case Enums.StatType.MP:
                            playerStat.MaxMP -= (int)(playerStat.MaxMP * data.Value);
                            break;
                        case Enums.StatType.Health:
                            playerStat.MaxHealth -= (int)(playerStat.MaxHealth * data.Value);
                            break;
                        case Enums.StatType.CriticalDamageRate:
                            playerStat.CriticalDamageRate -= playerStat.CriticalDamageRate * data.Value;
                            break;
                        case Enums.StatType.CriticalRate:
                            playerStat.CriticalRate -= playerStat.CriticalRate * data.Value;
                            break;
                        case Enums.StatType.ExpRate:
                            playerStat.ExpRate -= playerStat.ExpRate * data.Value;
                            break;
                    }
                }
                else
                {
                    switch (data.StatType)
                    {
                        case Enums.StatType.Attack:
                            playerStat.BaseAttack -= data.Value;
                            break;
                        case Enums.StatType.Defense:
                            playerStat.BaseDefense -= data.Value;
                            break;
                        case Enums.StatType.MP:
                            playerStat.MaxMP -= (int)data.Value;
                            break;
                        case Enums.StatType.Health:
                            playerStat.MaxHealth -= (int)data.Value;
                            break;
                        case Enums.StatType.CriticalDamageRate:
                            playerStat.CriticalDamageRate -= data.Value;
                            break;
                        case Enums.StatType.CriticalRate:
                            playerStat.CriticalRate -= data.Value;
                            break;
                        case Enums.StatType.ExpRate:
                            playerStat.ExpRate -= data.Value;
                            break;
                    }
                }
            }

            badge.Effects = null;
        }
    }
}
