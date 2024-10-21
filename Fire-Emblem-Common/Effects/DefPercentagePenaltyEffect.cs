using Fire_Emblem_Common.Enums;

namespace Fire_Emblem_Common.Effects;

public class DefPercentagePenaltyEffect:Effect
{
    private readonly double _percentage;
    private readonly AttackType _attackType;

    public DefPercentagePenaltyEffect(double percentage, AttackType attackType = AttackType.None)
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
            unit.Def.Penalty += penalty;
        }
        else if (_attackType == AttackType.FirstAttack)
        {
            unit.Def.FirstAttackPenalty += penalty;
        }
        else if (_attackType == AttackType.FollowUp)
        {
            unit.Def.FollowUpPenalty += penalty;
        }
    }
    
    private int GetPenalty(Unit unit)
    {
        return Convert.ToInt32(Math.Floor(_percentage * unit.Def.BaseValue));
    }
}