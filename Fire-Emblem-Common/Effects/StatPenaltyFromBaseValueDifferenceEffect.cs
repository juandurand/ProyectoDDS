using Fire_Emblem_Common.Helpers;
using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Models;
using Fire_Emblem_Common.PersonalizedInterfaces;

namespace Fire_Emblem_Common.Effects;

public class StatPenaltyFromBaseValueDifferenceEffect : Effect
{
    private readonly StatType _analizedBaseValueStatType;
    private readonly EnumList<StatType> _affectedStatTypes;
    private readonly int _maxPenalty;
    private readonly double _penaltyPercentage;
    
    public StatPenaltyFromBaseValueDifferenceEffect(StatType analizedBaseValueStatType,
        EnumList<StatType> affectedStatTypes, int maxPenalty, double penaltyPercentage) 
        : base(EffectsApplyOrder.FirstOrder)
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
            switch (stat)
            {
                case StatType.Atk:
                    unit.Atk.Penalty += penaltyValue;
                    break;
                case StatType.Def:
                    unit.Def.Penalty += penaltyValue;
                    break;
                case StatType.Spd:
                    unit.Spd.Penalty += penaltyValue;
                    break;
                case StatType.Res:
                    unit.Res.Penalty += penaltyValue;
                    break;
            }
        }
    }
    
    private int GetPenaltyValue(Unit unit)
    {
        int penaltyValue = Math.Min(UnitHelper.GetBaseValue(unit, _analizedBaseValueStatType) - 
                           UnitHelper.GetBaseValue(unit.ActualOpponent, _analizedBaseValueStatType), 0);
        penaltyValue = Math.Abs(penaltyValue);
        penaltyValue = Convert.ToInt32(Math.Floor(penaltyValue * _penaltyPercentage));
        
        return Math.Min(penaltyValue, _maxPenalty);
    }
}