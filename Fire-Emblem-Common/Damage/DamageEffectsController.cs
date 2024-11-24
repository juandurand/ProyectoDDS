using Fire_Emblem_Common.Enums;

namespace Fire_Emblem_Common.Damage;

public static class DamageEffectsController
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
    
    public static int GetTotalBonus(DamageEffects damageEffects, AttackType attackType)
    {
        int totalBonus = damageEffects.Bonus;

        totalBonus += GetSpecificAttackBonus(damageEffects, attackType);
        
        return totalBonus;
    }
    
    private static int GetSpecificAttackBonus(DamageEffects damageEffects, AttackType attackType)
    {
        return attackType switch
        {
            AttackType.FirstAttack => damageEffects.FirstAttackBonus,
            AttackType.FollowUp => damageEffects.FollowUpBonus,
            _ => 0
        };
    }
    
    public static double GetTotalPercentageReduction(DamageEffects damageEffects, AttackType attackType)
    {
        double totalPercentageReduction = damageEffects.PercentageReduction;
        
        totalPercentageReduction *= GetSpecificAttackPercentageReduction(damageEffects, attackType);
        
        return totalPercentageReduction;
    }
    
    private static double GetSpecificAttackPercentageReduction(DamageEffects damageEffects, AttackType attackType)
    {
        return attackType switch
        {
            AttackType.FirstAttack => damageEffects.FirstAttackPercentageReduction,
            AttackType.FollowUp => damageEffects.FollowUpPercentageReduction,
            _ => 0
        };
    }
}