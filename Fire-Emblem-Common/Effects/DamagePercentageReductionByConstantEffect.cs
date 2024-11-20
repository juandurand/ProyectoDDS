using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Effects;

public class DamagePercentageReductionByConstantEffect:Effect
{
    private readonly double _reduction;
    private readonly AttackType _attackType;

    public DamagePercentageReductionByConstantEffect(double reduction, AttackType attackType = AttackType.None)
        :base(EffectsApplyOrder.SecondOrder)
    {
        _reduction = reduction;
        _attackType = attackType;
    }

    public override void ApplyEffect(Unit unit)
    {
        double reductionFactor = unit.ActualOpponent.DamageEffects.ReductionOfPercentageReduction * _reduction;
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
}