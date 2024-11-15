using Fire_Emblem_Common.EDDs.Managers;
using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;
using Fire_Emblem_Common.PersonalizedInterfaces;

namespace Fire_Emblem_Common.Effects;

public class StatPenaltyFromBaseValueDifferenceEffect : Effect
{
    private readonly StatType _analizedBaseValueStatType;
    private readonly EnumList<StatType> _affectedStatTypes;
    private readonly int _maxPenalty;
    private readonly double _penaltyPercentage;
    
    public StatPenaltyFromBaseValueDifferenceEffect(StatType analizedBaseValueStatType, EnumList<StatType> affectedStatTypes,
        int maxPenalty, double penaltyPercentage) : base(EffectsApplyOrder.FirstOrder)
    {
        _analizedBaseValueStatType = analizedBaseValueStatType;
        _affectedStatTypes = affectedStatTypes;
        _maxPenalty = maxPenalty;
        _penaltyPercentage = penaltyPercentage;
    }
    
    public override void ApplyEffect(Unit unit)
    {
        int penaltyValue = GetPenaltyValue(unit);
        foreach (StatType stat in _affectedStatTypes)
        {
            if (stat == StatType.Atk)
            {
                unit.Atk.Penalty += penaltyValue;
            }
            else if (stat == StatType.Def)
            {
                unit.Def.Penalty += penaltyValue;
            }
            else if (stat == StatType.Spd)
            {
                unit.Spd.Penalty += penaltyValue;
            }
            else if (stat == StatType.Res)
            {
                unit.Res.Penalty += penaltyValue;
            }
        }
    }
    
    private int GetPenaltyValue(Unit unit)
    {
        int penaltyValue = Math.Min(UnitManager.GetBaseValue(unit, _analizedBaseValueStatType) - 
                           UnitManager.GetBaseValue(unit.ActualOpponent, _analizedBaseValueStatType), 0);
        penaltyValue = Math.Abs(penaltyValue);
        penaltyValue = Convert.ToInt32(Math.Floor(penaltyValue * _penaltyPercentage));
        return Math.Min(penaltyValue, _maxPenalty);
    }
}