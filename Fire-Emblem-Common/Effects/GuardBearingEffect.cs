using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Effects;

public class GuardBearingEffect:Effect
{
    private readonly AttackType _attackType;

    public GuardBearingEffect(AttackType attackType = AttackType.None)
        : base(EffectsApplyOrder.SecondOrder)
    {
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
        if (unit.FirstAttack == FirstAttack.ActuallyFirstAttacking || unit.FirstDefense == FirstDefense.ActuallyFirstDefending)
        {
            return 0.6;
        }

        return 0.3;
    }
}