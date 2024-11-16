using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Damage;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Effects;

public class SpecificExtraDamageEffect:Effect
{
    private readonly ExtraDamageCalculator _extraDamageCalculator;
    private readonly AttackType _attackType;

    public SpecificExtraDamageEffect(UnitRole analizedUnit, StatType analizedStat, double percentage, 
                                     StatType analizedStat2 = StatType.None, AttackType attackType = AttackType.None, int max = 10000)
        : base(EffectsApplyOrder.SecondOrder)
    {
        _extraDamageCalculator = new ExtraDamageCalculator(analizedUnit, analizedStat, analizedStat2, percentage, max);
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