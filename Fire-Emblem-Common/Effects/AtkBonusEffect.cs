using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Effects;

public class AtkBonusEffect:Effect
{
    private readonly int _atkBonus;
    private readonly AttackType _attackType;

    public AtkBonusEffect(int atkBonus, AttackType attackType = AttackType.None)
        : base(EffectsApplyOrder.FirstOrder)
    {
        _atkBonus = atkBonus;
        _attackType = attackType;
    }

    public override void ApplyEffect(Unit unit)
    {
        if (_attackType == AttackType.None)
        {
            unit.Atk.Bonus += _atkBonus;
        }
        else if (_attackType == AttackType.FirstAttack)
        {
            unit.Atk.FirstAttackBonus += _atkBonus;
        }
        else if (_attackType == AttackType.FollowUp)
        {
            unit.Atk.FollowUpBonus += _atkBonus;
        }
    }
}