namespace Fire_Emblem_Common.Conditions;

public class HpPercentageCondition:Condition
{
    private readonly double _requiredPercentage;
    private readonly string _analyzedUnit;
    
    public HpPercentageCondition(double requiredPercentage, string analyzedUnit)
    {
        _analyzedUnit = analyzedUnit;
        _requiredPercentage = requiredPercentage;
    }
    
    public override bool IsConditionSatisfied(Dictionary<string, object> roundInfo, string unitOwnerName)
    {
        (Unit unit, Unit rival) = GetUnits(roundInfo, unitOwnerName);
        
        if (_analyzedUnit == "Unit")
        {
            return unit.GetHpPercentage() <= _requiredPercentage;
        }
        return rival.GetHpPercentage() >= _requiredPercentage;
        
    }
}