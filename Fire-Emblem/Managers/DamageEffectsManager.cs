using Fire_Emblem_Common.Models;

namespace Fire_Emblem.Managers;

public static class DamageEffectsManager
{
    public static void ResetEffects(DamageEffects damageEffects)
    {
        damageEffects.Bonus = 0;
        damageEffects.Penalty = 0;
        damageEffects.PercentageReduction = 1.0;
        damageEffects.ReductionOfPercentageReduction = 1.0;
        damageEffects.FirstAttackBonus = 0;
        damageEffects.FollowUpBonus = 0;
        damageEffects.FirstAttackPercentageReduction = 1.0;
        damageEffects.FollowUpPercentageReduction = 1.0;
    }
}