namespace Fire_Emblem_Common;

public static class DamageEffectsController
{
    public static void ResetEffects(DamageEffects damageEffects)
    {
        damageEffects.Bonus = 0;
        damageEffects.Penalty = 0;
        damageEffects.PercentageReduction = 1.0;
        damageEffects.FirstAttackBonus = 0;
        damageEffects.FollowUpBonus = 0;
        damageEffects.FirstAttackPercentageReduction = 1.0;
        damageEffects.FollowUpPercentageReduction = 1.0;
    }
    
    public static int GetTotalBonus(DamageEffects damageEffects, AttackType attackType)
    {
        int totalBonus = damageEffects.Bonus;
        
        if (attackType == AttackType.FirstAttack) totalBonus += damageEffects.FirstAttackBonus;
        if (attackType == AttackType.FollowUp) totalBonus += damageEffects.FollowUpBonus;
        
        return totalBonus;
    }
    
    public static double GetTotalPercentageReduction(DamageEffects damageEffects, AttackType attackType)
    {
        double totalPercentageReduction = damageEffects.PercentageReduction;
        
        if (attackType == AttackType.FirstAttack) totalPercentageReduction *= damageEffects.FirstAttackPercentageReduction;
        if (attackType == AttackType.FollowUp) totalPercentageReduction *= damageEffects.FollowUpPercentageReduction;
        
        return totalPercentageReduction;
    }
}