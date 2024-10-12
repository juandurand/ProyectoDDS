namespace Fire_Emblem_Common.Effects;

public class SpecificExtraDamageEffect:Effectt
{
    private readonly ExtraDamageCalculator _extraDamageCalculator;
    private readonly string _attackType;

    public SpecificExtraDamageEffect(string analizedUnit, string analizedStat, double percentage, string attackType = "All")
        : base("Extra Damage", 2)
    {
        _extraDamageCalculator = new ExtraDamageCalculator(analizedUnit, analizedStat, percentage);
        _attackType = attackType;
    }

    public override void ApplyEffect(Unit unit)
    {
        int extraDamage = _extraDamageCalculator.GetExtraDamage(unit);
        if (_attackType == "All")
        {
            unit.Damage.Bonus += extraDamage;
        }
        else if (_attackType == "First Attack")
        {
            unit.Damage.FirstAttackBonus += extraDamage;
        }
        else
        {
            unit.Damage.FollowUpBonus += extraDamage;
        }
    }

    
}