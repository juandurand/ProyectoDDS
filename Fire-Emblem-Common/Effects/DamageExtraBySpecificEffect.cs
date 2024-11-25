using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Damage;
using Fire_Emblem_Common.Models;

namespace Fire_Emblem_Common.Effects;

public class DamageExtraBySpecificEffect:Effect
{
    private readonly ExtraDamageCalculator _extraDamageCalculator;
    private readonly AttackType _attackType;

    public DamageExtraBySpecificEffect(UnitRole analyzedUnit, StatType firstAnalyzedStat, double percentage,
                StatType secondAnalyzedStat = StatType.None, AttackType attackType = AttackType.None, int max = 10000)
        : base(EffectsApplyOrder.SecondOrder)
    {
        _extraDamageCalculator = new ExtraDamageCalculator(analyzedUnit, firstAnalyzedStat, secondAnalyzedStat,
                                                           percentage, max);
        _attackType = attackType;
    }

    public override void ApplyEffect(Unit unit)
    {
        int extraDamage = _extraDamageCalculator.GetExtraDamage(unit);

        switch (_attackType)
        {
            case AttackType.None:
                unit.DamageEffects.Bonus += extraDamage;
                break;
            case AttackType.FirstAttack:
                unit.DamageEffects.FirstAttackBonus += extraDamage;
                break;
            case AttackType.FollowUp:
                unit.DamageEffects.FollowUpBonus += extraDamage;
                break;
        }
    }
}