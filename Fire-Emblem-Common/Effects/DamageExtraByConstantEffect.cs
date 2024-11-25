using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Models;

namespace Fire_Emblem_Common.Effects;

public class DamageExtraByConstantEffect:Effect
{
    private readonly int _damageBonus;
    private readonly AttackType _attackType;

    public DamageExtraByConstantEffect(int damageBonus, AttackType attackType = AttackType.None)
        : base(EffectsApplyOrder.SecondOrder)
    {
        _damageBonus = damageBonus;
        _attackType = attackType;
    }

    public override void ApplyEffect(Unit unit)
    {
        switch (_attackType)
        {
            case AttackType.None:
                unit.DamageEffects.Bonus += _damageBonus;
                break;
            case AttackType.FirstAttack:
                unit.DamageEffects.FirstAttackBonus += _damageBonus;
                break;
            case AttackType.FollowUp:
                unit.DamageEffects.FollowUpBonus += _damageBonus;
                break;
        }
    }
}