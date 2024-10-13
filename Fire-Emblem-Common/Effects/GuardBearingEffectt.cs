namespace Fire_Emblem_Common.Effects;

public class GuardBearingEffectt:Effectt
{
    private readonly string _attackType;

    public GuardBearingEffectt(string attackType = "All")
        : base("Percentage Reduction", 1)
    {
        _attackType = attackType;
    }

    public override void ApplyEffect(Unit unit)
    {
        double reductionFactor = 0.3;
        
        if (unit.FirstAttack == 1 || unit.FirstDefense == 1)
        {
            reductionFactor = 0.6;
        }
        
        if (_attackType == "All")
        {
            unit.Damage.PercentageReduction *= (1 - reductionFactor);
        }
        else if (_attackType == "First Attack")
        {
            unit.Damage.FirstAttackPercentageReduction *= (1 - reductionFactor);
        }
        else
        {
            unit.Damage.FollowUpPercentageReduction *= (1 - reductionFactor);
        }
    }
}