using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Models;
using Fire_Emblem_Common.Helpers;

namespace Fire_Emblem_Common.Effects;

public class StatPenaltyByPercentageOfBaseValueEffect:Effect
{
    private readonly double _percentage;
    private readonly StatType _statType;
    private readonly AttackType _attackType;

    public StatPenaltyByPercentageOfBaseValueEffect(double percentage, StatType statType,
        AttackType attackType = AttackType.None) : base(EffectsApplyOrder.FirstOrder)
    {
        _percentage = percentage;
        _statType = statType;
        _attackType = attackType;
    }

    public override void ApplyEffect(Unit unit)
    {
        int penaltyValue = GetPenalty(unit);
    
        switch (_statType)
        {
            case StatType.Atk:
                StatHelper.ApplyPenalty(unit.Atk, penaltyValue, _attackType);
                break;
            case StatType.Def:
                StatHelper.ApplyPenalty(unit.Def, penaltyValue, _attackType);
                break;
            case StatType.Res:
                StatHelper.ApplyPenalty(unit.Res, penaltyValue, _attackType);
                break;
            case StatType.Spd:
                StatHelper.ApplyPenalty(unit.Spd, penaltyValue, _attackType);
                break;
        }
    }

    private int GetPenalty(Unit unit)
    {
        double baseValue = _statType switch
        {
            StatType.Atk => unit.Atk.BaseValue,
            StatType.Def => unit.Def.BaseValue,
            StatType.Res => unit.Res.BaseValue,
            StatType.Spd => unit.Spd.BaseValue,
            _ => 0
        };
    
        return Convert.ToInt32(Math.Floor(_percentage * baseValue));
    }
}