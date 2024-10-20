using Fire_Emblem_Common.Enums;

namespace Fire_Emblem_Common.Effects;

public class PercentageReductionByHpEffectt:Effectt
{
    private readonly double _percentage;
    private readonly AttackType _attackType;

    public PercentageReductionByHpEffectt(double percentage, AttackType attackType = AttackType.None)
        :base(2)
    {
        _percentage = percentage;
        _attackType = attackType;
    }

    public override void ApplyEffect(Unit unit)
    {
        double reductionFactor = GetReductionFactor(unit);
        
        if (_attackType == AttackType.None)
        {
            unit.DamageEffects.PercentageReduction *= (1 - reductionFactor);
        }
        else if (_attackType == AttackType.FirstAttack)
        {
            unit.DamageEffects.FirstAttackPercentageReduction *= (1 - reductionFactor);
        }
        else if (_attackType == AttackType.FollowUp)
        {
            unit.DamageEffects.FollowUpPercentageReduction *= (1 - reductionFactor);
        }
    }

    private double GetReductionFactor(Unit unit)
    {
        double reductionFactor = _percentage * HealthStatusController.GetHpPercentage(unit.ActualOpponent.HealthStatus);
        return Math.Truncate(reductionFactor * 100) / 100;
    }
}