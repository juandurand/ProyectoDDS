namespace Fire_Emblem_Common.Models;

public class DamageEffects
{
    public int Bonus;
    public int FirstAttackBonus;
    public int FollowUpBonus;
    
    public int Penalty;
    
    public double PercentageReduction;
    public double FirstAttackPercentageReduction;
    public double FollowUpPercentageReduction;
    
    public double ReductionOfPercentageReduction;

    public DamageEffects()
    {
        Bonus = 0;
        FirstAttackBonus = 0;
        FollowUpBonus = 0;
        Penalty = 0;
        PercentageReduction = 1.0;
        FirstAttackPercentageReduction = 1.0;
        FollowUpPercentageReduction = 1.0;
        ReductionOfPercentageReduction = 1.0;
    }
}