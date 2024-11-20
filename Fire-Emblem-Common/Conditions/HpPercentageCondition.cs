using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;
using Fire_Emblem_Common.EDDs.Managers;

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
        if (_analyzedUnit == UnitRole.Unit)
        {
            return HealthStatusManager.GetHpPercentage(roundInfo.SkillOwner.HealthStatus) <= _requiredPercentage;
        }

        if (_analyzedUnit == UnitRole.Rival)
        {
            return HealthStatusManager.GetHpPercentage(roundInfo.Rival.HealthStatus) >= _requiredPercentage;
        }

        return false;
    }
}