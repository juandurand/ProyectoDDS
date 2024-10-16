namespace Fire_Emblem_Common;

public static class StatController
{
    public static int GetTotalStat(Stat stat, AttackType attackType)
    {
        int totalStat = stat.BaseValue;

        if (!stat.BonusNeutralized)
        {
            totalStat += stat.Bonus;
            totalStat += GetSpecificAttackBonus(stat, attackType);
        }

        if (!stat.PenaltyNeutralized)
        {
            totalStat -= stat.Penalty;
            totalStat -= GetSpecificAttackPenalty(stat, attackType);
        }

        return totalStat;
    }

    private static int GetSpecificAttackBonus(Stat stat, AttackType attackType)
    {
        if (attackType == AttackType.FirstAttack) return stat.FirstAttackBonus;
        if (attackType == AttackType.FollowUp) return stat.FollowUpBonus;
        return 0;
    }

    private static int GetSpecificAttackPenalty(Stat stat, AttackType attackType)
    {
        if (attackType == AttackType.FirstAttack) return stat.FirstAttackPenalty;
        if (attackType == AttackType.FollowUp) return stat.FollowUpPenalty;
        return 0;
    }
    
    public static void ResetEffects(Stat stat)
    {
        ResetBonus(stat);
        ResetPenalty(stat);
    }

    private static void ResetBonus(Stat stat)
    {
        stat.Bonus = 0;
        stat.FirstAttackBonus = 0;
        stat.FollowUpBonus = 0;
        stat.BonusNeutralized = false;
    }
    
    private static void ResetPenalty(Stat stat)
    {
        stat.Penalty = 0;
        stat.FirstAttackPenalty = 0;
        stat.FollowUpPenalty = 0;
        stat.PenaltyNeutralized = false;
    }
}