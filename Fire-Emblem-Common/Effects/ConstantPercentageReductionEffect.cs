using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Effects;

public class ConstantPercentageReductionEffect:Effect
{
    private readonly double _reduction;
    private readonly AttackType _attackType;

    public ConstantPercentageReductionEffect(double reduction, AttackType attackType = AttackType.None)
        :base(EffectsApplyOrder.SecondOrder)
    {
        _reduction = reduction;
        _attackType = attackType;
    }

    public override void ApplyEffect(Unit unit)
    {
        if (_attackType == AttackType.None)
        {
            unit.DamageEffects.PercentageReduction *= (1 - _reduction);
        }
        else if (_attackType == AttackType.FirstAttack)
        {
            unit.DamageEffects.FirstAttackPercentageReduction *= (1 - _reduction);
        }
        else if (_attackType == AttackType.FollowUp)
        {
            unit.DamageEffects.FollowUpPercentageReduction *= (1 - _reduction);
        }
    }
}