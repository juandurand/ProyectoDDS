using Fire_Emblem_Common.Enums;

namespace Fire_Emblem_Common.Effects;

public class ConstantExtraDamageEffect:Effect
{
    private readonly int _damageBonus;
    private readonly AttackType _attackType;

    public ConstantExtraDamageEffect(int damageBonus, AttackType attackType = AttackType.None)
        : base(EffectsApplyOrder.SecondOrder)
    {
        _damageBonus = damageBonus;
        _attackType = attackType;
    }

    public override void ApplyEffect(Unit unit)
    {
        if (_attackType == AttackType.None)
        {
            unit.DamageEffects.Bonus += _damageBonus;
        }
        else if (_attackType == AttackType.FirstAttack)
        {
            unit.DamageEffects.FirstAttackBonus += _damageBonus;
        }
        else if (_attackType == AttackType.FollowUp)
        {
            unit.DamageEffects.FollowUpBonus += _damageBonus;
        }
    }
}