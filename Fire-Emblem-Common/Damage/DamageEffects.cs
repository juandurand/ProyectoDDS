namespace Fire_Emblem_Common.Damage;

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
        DamageEffectsController.ResetEffects(this);
    }
}