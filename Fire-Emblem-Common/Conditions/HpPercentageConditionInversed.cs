using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;
using Fire_Emblem_Common.EDDs.Managers;

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
        return _analyzedUnit switch
        {
            UnitRole.Unit => Math.Round(HealthStatusManager.GetHpPercentage(roundInfo.SkillOwner.HealthStatus), 2) >=
                             _requiredPercentage,
            UnitRole.Rival => Math.Round(HealthStatusManager.GetHpPercentage(roundInfo.Rival.HealthStatus), 2) <=
                              _requiredPercentage,
            _ => false
        };
    }
}