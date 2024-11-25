using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Models;
using Fire_Emblem_Common.Helpers;

namespace Fire_Emblem_Common.Effects;

public class DamagePercentageReductionByHpEffect:Effect
{
    private readonly double _percentage;
    private readonly AttackType _attackType;

    public DamagePercentageReductionByHpEffect(double percentage, AttackType attackType = AttackType.None)
        :base(EffectsApplyOrder.SecondOrder)
    {
        _percentage = percentage;
        _attackType = attackType;
    }

    public override void ApplyEffect(Unit unit)
    {
        double reductionFactor = GetReductionFactor(unit);
        reductionFactor = unit.ActualOpponent.DamageEffects.ReductionOfPercentageReduction * reductionFactor;

        switch (_attackType)
        {
            case AttackType.None:
                unit.DamageEffects.PercentageReduction *= (1 - reductionFactor);
                break;
            case AttackType.FirstAttack:
                unit.DamageEffects.FirstAttackPercentageReduction *= (1 - reductionFactor);
                break;
            case AttackType.FollowUp:
                unit.DamageEffects.FollowUpPercentageReduction *= (1 - reductionFactor);
                break;
        }
    }

    private double GetReductionFactor(Unit unit)
    {
        double reductionFactor = _percentage * HealthStatusHelper.GetHpPercentage(unit.ActualOpponent.HealthStatus);
        int oneHundred = 100;
        return Math.Truncate(reductionFactor * oneHundred) / oneHundred;
    }
}