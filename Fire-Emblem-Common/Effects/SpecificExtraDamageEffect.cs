namespace Fire_Emblem_Common.Effects;

public class SpecificExtraDamageEffect:Effectt
{
    private readonly ExtraDamageCalculator _extraDamageCalculator;
    private readonly AttackType _attackType;

    public SpecificExtraDamageEffect(UnitRole analizedUnit, StatType analizedStat, double percentage, StatType analizedStat2 = StatType.None, AttackType attackType = AttackType.None)
        : base(2)
    {
        _extraDamageCalculator = new ExtraDamageCalculator(analizedUnit, analizedStat, analizedStat2, percentage);
        _attackType = attackType;
    }

    public override void ApplyEffect(Unit unit)
    {
        int extraDamage = _extraDamageCalculator.GetExtraDamage(unit);
        if (_attackType == AttackType.None)
        {
            unit.Damage.Bonus += extraDamage;
        }
        else if (_attackType == AttackType.FirstAttack)
        {
            unit.Damage.FirstAttackBonus += extraDamage;
        }
        else
        {
            unit.Damage.FollowUpBonus += extraDamage;
        }
    }

    
}