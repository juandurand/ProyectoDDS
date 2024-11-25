using Fire_Emblem_Common.Models;
using Fire_Emblem_Common.Enums;

namespace Fire_Emblem_Common.Helpers;

public static class DamageEffectsHelper
{
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