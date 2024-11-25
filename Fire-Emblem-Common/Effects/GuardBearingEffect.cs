using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Models;

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
        double firstAttackOrDefenseValue = 0.6;
        double defaultValue = 0.3;
        
        if (unit.FirstAttack == FirstAttack.ActuallyFirstAttacking || 
            unit.FirstDefense == FirstDefense.ActuallyFirstDefending)
        {
            return firstAttackOrDefenseValue;
        }

        return defaultValue;
    }
}