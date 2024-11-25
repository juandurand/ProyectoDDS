using Fire_Emblem_Common.Models;
using Fire_Emblem_Common.Enums;

namespace Fire_Emblem_Common.Helpers;

public static class StatHelper
{
    public static int GetTotalStat(Stat stat, AttackType attackType)
    {
        int totalStat = stat.BaseValue;

        if (!stat.BonusNeutralized)
        {
            totalStat += stat.Bonus;
            totalStat += GetSpecificAttackBonus(stat, attackType);
        }

        if (stat.PenaltyNeutralized)
        {
            return totalStat;
        }
        
        totalStat -= stat.Penalty;
        totalStat -= GetSpecificAttackPenalty(stat, attackType);

        return totalStat;
    }

    private static int GetSpecificAttackBonus(Stat stat, AttackType attackType)
    {
        return attackType switch
        {
            AttackType.FirstAttack => stat.FirstAttackBonus,
            AttackType.FollowUp => stat.FollowUpBonus,
            _ => 0
        };
    }

    private static int GetSpecificAttackPenalty(Stat stat, AttackType attackType)
    {
        return attackType switch
        {
            AttackType.FirstAttack => stat.FirstAttackPenalty,
            AttackType.FollowUp => stat.FollowUpPenalty,
            _ => 0
        };
    }
    
    public static void ApplyBonus(Stat stat, int bonusValue, AttackType attackType)
    {
        switch (attackType)
        {
            case AttackType.None:
                stat.Bonus += bonusValue;
                break;
            case AttackType.FirstAttack:
                stat.FirstAttackBonus += bonusValue;
                break;
            case AttackType.FollowUp:
                stat.FollowUpBonus += bonusValue;
                break;
        }
    }

    public static void ApplyPenalty(Stat stat, int penaltyValue, AttackType attackType = AttackType.None)
    {
        switch (attackType)
        {
            case AttackType.None:
                stat.Penalty += penaltyValue;
                break;
            case AttackType.FirstAttack:
                stat.FirstAttackPenalty += penaltyValue;
                break;
            case AttackType.FollowUp:
                stat.FollowUpPenalty += penaltyValue;
                break;
        }
    }
}