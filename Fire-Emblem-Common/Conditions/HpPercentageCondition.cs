using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Models;
using Fire_Emblem_Common.Helpers;

namespace Fire_Emblem_Common.Conditions;

public class HpPercentageCondition:Condition
{
    private readonly double _requiredPercentage;
    private readonly UnitRole _analyzedUnit;
    
    public HpPercentageCondition(double requiredPercentage, UnitRole analyzedUnit) 
    {
        _analyzedUnit = analyzedUnit;
        _requiredPercentage = requiredPercentage;
    }
    
    public override bool IsConditionSatisfied(RoundInfo roundInfo)
    {
        Unit skillOwner = GetSkillOwner(roundInfo);
        
        return _analyzedUnit switch
        {
            UnitRole.Unit => HealthStatusHelper.GetHpPercentage(skillOwner.HealthStatus) <= 
                             _requiredPercentage,
            UnitRole.Rival => HealthStatusHelper.GetHpPercentage(skillOwner.ActualOpponent.HealthStatus) >= 
                              _requiredPercentage,
            _ => false
        };
    }
}