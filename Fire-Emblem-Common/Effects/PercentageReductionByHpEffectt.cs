namespace Fire_Emblem_Common.Effects;

public class PercentageReductionByHpEffectt:Effectt
{
    private readonly double _percentage;
    private readonly string _attackType;

    public PercentageReductionByHpEffectt(double percentage, string attackType = "All")
        :base("Percentage Reduction", 2)
    {
        _percentage = percentage;
        _attackType = attackType;
    }

    public override void ApplyEffect(Unit unit)
    {
        double reductionFactor = _percentage * unit.ActualOpponent.Hp.GetHpPercentage();
        reductionFactor = Math.Truncate(reductionFactor * 100) / 100;
        
        
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