using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;
using Fire_Emblem_Common.EDDs.Managers;

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
        if (_statType == StatType.Atk)
        {
            StatManager.ApplyPenalty(unit.Atk, _penaltyValue);
        }
        else if (_statType == StatType.Def)
        {
            StatManager.ApplyPenalty(unit.Def, _penaltyValue);
        }
        else if (_statType == StatType.Res)
        {
            StatManager.ApplyPenalty(unit.Res, _penaltyValue);
        }
        else if (_statType == StatType.Spd)
        {
            StatManager.ApplyPenalty(unit.Spd, _penaltyValue);
        }
    }
}