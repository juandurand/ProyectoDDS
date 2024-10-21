using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.PersonalizedInterfaces;

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
        (Unit starter, Unit rival, Unit skillOwner) = GetUnits(roundInfo);
        
        if (_analyzedUnit == UnitRole.Unit)
        {
            return HealthStatusController.GetHpPercentage(skillOwner.HealthStatus) <= _requiredPercentage;
        }
        return HealthStatusController.GetHpPercentage(rival.HealthStatus) >= _requiredPercentage;
    }
}