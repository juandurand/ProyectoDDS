using Fire_Emblem_Common.Models;

namespace Fire_Emblem.Managers;

public static class StatManager
{
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