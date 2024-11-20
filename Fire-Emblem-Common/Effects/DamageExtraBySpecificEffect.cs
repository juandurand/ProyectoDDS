using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Damage;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Effects;

public class DamageExtraBySpecificEffect:Effect
{
    private readonly ExtraDamageCalculator _extraDamageCalculator;
    private readonly AttackType _attackType;

    public DamageExtraBySpecificEffect(UnitRole analizedUnit, StatType firstAnalizedStat, double percentage, 
                                     StatType secondAnalizedStat = StatType.None, AttackType attackType = AttackType.None, int max = 10000)
        : base(EffectsApplyOrder.SecondOrder)
    {
        _extraDamageCalculator = new ExtraDamageCalculator(analizedUnit, firstAnalizedStat, secondAnalizedStat, percentage, max);
        _attackType = attackType;
    }

    public override void ApplyEffect(Unit unit)
    {
        int extraDamage = _extraDamageCalculator.GetExtraDamage(unit);
        
        if (_attackType == AttackType.None)
        {
            unit.DamageEffects.Bonus += extraDamage;
        }
        else if (_attackType == AttackType.FirstAttack)
        {
            unit.DamageEffects.FirstAttackBonus += extraDamage;
        }
        else if (_attackType == AttackType.FollowUp)
        {
            unit.DamageEffects.FollowUpBonus += extraDamage;
        }
    }

    
}