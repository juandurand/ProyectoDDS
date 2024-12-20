using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Effects;

public class ResPercentagePenaltyEffect:Effect
{
    private readonly double _percentage;
    private readonly AttackType _attackType;

    public ResPercentagePenaltyEffect(double percentage, AttackType attackType = AttackType.None)
        : base(EffectsApplyOrder.FirstOrder)
    {
        _percentage = percentage;
        _attackType = attackType;
    }

    public override void ApplyEffect(Unit unit)
    {
        int penalty = GetPenalty(unit);
        
        if (_attackType == AttackType.None)
        {
            unit.Res.Penalty += penalty;
        }
        else if (_attackType == AttackType.FirstAttack)
        {
            unit.Res.FirstAttackPenalty += penalty;
        }
        else if (_attackType == AttackType.FollowUp)
        {
            unit.Res.FollowUpPenalty += penalty;
        }
    }

    private int GetPenalty(Unit unit)
    {
        return Convert.ToInt32(Math.Floor(_percentage * unit.Res.BaseValue));
    }
}