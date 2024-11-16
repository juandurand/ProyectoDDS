using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;
using Fire_Emblem_Common.EDDs.Managers;

namespace Fire_Emblem_Common.Effects;

public class PercentageReductionByHpEffect:Effect
{
    private readonly double _percentage;
    private readonly AttackType _attackType;

    public PercentageReductionByHpEffect(double percentage, AttackType attackType = AttackType.None)
        :base(EffectsApplyOrder.SecondOrder)
    {
        _percentage = percentage;
        _attackType = attackType;
    }

    public override void ApplyEffect(Unit unit)
    {
        double reductionFactor = GetReductionFactor(unit);
        reductionFactor = unit.ActualOpponent.DamageEffects.ReductionOfPercentageReduction * reductionFactor;
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
        double reductionFactor = _percentage * HealthStatusManager.GetHpPercentage(unit.ActualOpponent.HealthStatus);
        return Math.Truncate(reductionFactor * 100) / 100;
    }
}