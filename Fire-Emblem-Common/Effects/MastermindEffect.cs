using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Effects;

public class MastermindEffect:Effect
{
    private readonly int _damageBonus;
    private readonly AttackType _attackType;

    public MastermindEffect(int damageBonus, AttackType attackType = AttackType.None)
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