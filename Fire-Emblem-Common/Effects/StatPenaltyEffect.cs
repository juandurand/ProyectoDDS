using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Models;
using Fire_Emblem_Common.Helpers;

namespace Fire_Emblem_Common.Effects;

public class StatPenaltyEffect:Effect
{
    private readonly int _penaltyValue;
    private readonly StatType _statType;

    public StatPenaltyEffect(int penaltyValue, StatType statType)
        : base(EffectsApplyOrder.FirstOrder)
    {
        _penaltyValue = penaltyValue;
        _statType = statType;
    }

    public override void ApplyEffect(Unit unit)
    {
        switch (_statType)
        {
            case StatType.Atk:
                StatHelper.ApplyPenalty(unit.Atk, _penaltyValue);
                break;
            case StatType.Def:
                StatHelper.ApplyPenalty(unit.Def, _penaltyValue);
                break;
            case StatType.Res:
                StatHelper.ApplyPenalty(unit.Res, _penaltyValue);
                break;
            case StatType.Spd:
                StatHelper.ApplyPenalty(unit.Spd, _penaltyValue);
                break;
        }
    }
}