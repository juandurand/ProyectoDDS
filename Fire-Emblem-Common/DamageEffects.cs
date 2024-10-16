namespace Fire_Emblem_Common;

public class DamageEffects
{
    public int Bonus;
    public int FirstAttackBonus;
    public int FollowUpBonus;
    
    public int Penalty;
    
    public double PercentageReduction;
    public double FirstAttackPercentageReduction;
    public double FollowUpPercentageReduction;

    public DamageEffects()
    {
        DamageEffectsController.ResetEffects(this);
    }
}