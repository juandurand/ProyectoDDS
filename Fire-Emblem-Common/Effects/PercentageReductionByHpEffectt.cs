namespace Fire_Emblem_Common.Effects;

public class PercentageReductionByHpEffectt:Effectt
{
    private readonly double _percentage;
    private readonly string _attackType;

    public PercentageReductionByHpEffectt(double percentage, string attackType = "All")
        :base(2)
    {
        _percentage = percentage;
        _attackType = attackType;
    }

    public override void ApplyEffect(Unit unit)
    {
        double reductionFactor = _percentage * HealthStatusController.GetHpPercentage(unit.ActualOpponent.HealthStatus);
        reductionFactor = Math.Truncate(reductionFactor * 100) / 100;
        
        
        if (_attackType == "All")
        {
            unit.DamageEffects.PercentageReduction *= (1 - reductionFactor);
        }
        else if (_attackType == "First Attack")
        {
            unit.DamageEffects.FirstAttackPercentageReduction *= (1 - reductionFactor);
        }
        else
        {
            unit.DamageEffects.FollowUpPercentageReduction *= (1 - reductionFactor);
        }
    }
}