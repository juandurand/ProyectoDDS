using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;
using Fire_Emblem_Common.EDDs.Managers;

namespace Fire_Emblem_Common.Effects;

public class StatPenaltyByPercentageOfBaseValueEffect:Effect
{
    private readonly double _percentage;
    private readonly StatType _statType;
    private readonly AttackType _attackType;

    public StatPenaltyByPercentageOfBaseValueEffect(double percentage, StatType statType, AttackType attackType = AttackType.None)
        : base(EffectsApplyOrder.FirstOrder)
    {
        _percentage = percentage;
        _statType = statType;
        _attackType = attackType;
    }

    public override void ApplyEffect(Unit unit)
    {
        int penaltyValue = GetPenalty(unit);
        
        if (_statType == StatType.Atk)
        {
            StatManager.ApplyPenalty(unit.Atk, penaltyValue, _attackType);
        }
        else if (_statType == StatType.Def)
        {
            StatManager.ApplyPenalty(unit.Def, penaltyValue, _attackType);
        }
        else if (_statType == StatType.Res)
        {
            StatManager.ApplyPenalty(unit.Res, penaltyValue, _attackType);
        }
        else if (_statType == StatType.Spd)
        {
            StatManager.ApplyPenalty(unit.Spd, penaltyValue, _attackType);
        }
    }
    
    private int GetPenalty(Unit unit)
    {
        if (_statType == StatType.Atk)
        {
            return Convert.ToInt32(Math.Floor(_percentage * unit.Atk.BaseValue));
        }
        if (_statType == StatType.Def)
        {
            return Convert.ToInt32(Math.Floor(_percentage * unit.Def.BaseValue));
        }
        if (_statType == StatType.Res)
        {
            return Convert.ToInt32(Math.Floor(_percentage * unit.Res.BaseValue));
        }
        if (_statType == StatType.Spd)
        {
            return Convert.ToInt32(Math.Floor(_percentage * unit.Spd.BaseValue));
        }
        return 0;
    }
}