namespace Fire_Emblem_Common;

public class UnitDamageInfo
{
    public int Bonus;
    public int FirstAttackBonus;
    public int FollowUpBonus;
    
    public int Penalty;
    
    public double PercentageReduction;
    public double FirstAttackPercentageReduction;
    public double FollowUpPercentageReduction;

    public UnitDamageInfo()
    {
        ResetEffects();
    }

    public void ResetEffects()
    {
        Bonus = 0;
        Penalty = 0;
        PercentageReduction = 1.0;
        FirstAttackBonus = 0;
        FollowUpBonus = 0;
        FirstAttackPercentageReduction = 1.0;
        FollowUpPercentageReduction = 1.0;
    }
    
    public int GetTotalBonus(AttackType attackType)
    {
        int totalBonus = Bonus;
        
        if (attackType == AttackType.FirstAttack) totalBonus += FirstAttackBonus;
        if (attackType == AttackType.FollowUp) totalBonus += FollowUpBonus;
        
        return totalBonus;
    }
    
    public double GetTotalPercentageReduction(AttackType attackType)
    {
        double totalPercentageReduction = PercentageReduction;
        
        if (attackType == AttackType.FirstAttack) totalPercentageReduction *= FirstAttackPercentageReduction;
        if (attackType == AttackType.FollowUp) totalPercentageReduction *= FollowUpPercentageReduction;
        
        return totalPercentageReduction;
    }
}