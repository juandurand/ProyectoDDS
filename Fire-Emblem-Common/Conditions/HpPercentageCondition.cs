using Fire_Emblem_Common.Enums;

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
            if (_requiredPercentage > 0)
                return HealthStatusController.GetHpPercentage(skillOwner.HealthStatus) <= _requiredPercentage;
            return Math.Round(HealthStatusController.GetHpPercentage(skillOwner.HealthStatus), 2) >= -_requiredPercentage;
        }
        return HealthStatusController.GetHpPercentage(rival.HealthStatus) >= _requiredPercentage;
        
    }
}