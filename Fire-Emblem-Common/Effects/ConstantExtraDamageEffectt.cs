namespace Fire_Emblem_Common.Effects;

public class ConstantExtraDamageEffectt:Effectt
{
    private readonly int _damageBonus;
    private readonly string _attackType;

    public ConstantExtraDamageEffectt(int damageBonus, string attackType = "All")
        : base("Extra Damage", 2)
    {
        _damageBonus = damageBonus;
        _attackType = attackType;
    }

    public override void ApplyEffect(Unit unit)
    {
        if (_attackType == "All")
        {
            unit.Damage.Bonus += _damageBonus;
        }
        else if (_attackType == "First Attack")
        {
            unit.Damage.FirstAttackBonus += _damageBonus;
        }
        else
        {
            unit.Damage.FollowUpBonus += _damageBonus;
        }
    }
}