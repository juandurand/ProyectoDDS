using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Models;
using Fire_Emblem_Common.Helpers;

namespace Fire_Emblem_Common.Conditions;

public class HpPercentageConditionInversed:Condition
{
    private readonly double _requiredPercentage;
    private readonly UnitRole _analyzedUnit;
    
    public HpPercentageConditionInversed(double requiredPercentage, UnitRole analyzedUnit) 
    {
        _analyzedUnit = analyzedUnit;
        _requiredPercentage = requiredPercentage;
    }
    
    public override bool IsConditionSatisfied(RoundInfo roundInfo)
    {
        Unit skillOwner = GetSkillOwner(roundInfo);
        
        return _analyzedUnit switch
        {
            UnitRole.Unit => Math.Round(HealthStatusHelper.GetHpPercentage(skillOwner.HealthStatus), 2) >=
                             _requiredPercentage,
            UnitRole.Rival => Math.Round(HealthStatusHelper.GetHpPercentage(
                                  skillOwner.ActualOpponent.HealthStatus), 2) <= _requiredPercentage,
            _ => false
        };
    }
}