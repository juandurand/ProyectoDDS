using Fire_Emblem_Common;
namespace Fire_Emblem.Conditions;

public class HPPercentageCondition:Condition
{
    private readonly double _requiredPercentage;
    private readonly string _analyzedUnit;
    
    public HPPercentageCondition(double requiredPercentage, string analyzedUnit)
    {
        _analyzedUnit = analyzedUnit;
        _requiredPercentage = requiredPercentage;
    }
    
    public override bool IsConditionSatisfied(Dictionary<string, object> roundInfo)
    {
        Unit unit = roundInfo["Unit"] as Unit;
        Unit rival = roundInfo["Rival"] as Unit;
        
        if (_analyzedUnit == "Unit")
        {
            return unit.GetHPPercentage() <= _requiredPercentage;
        }
        return rival.GetHPPercentage() <= _requiredPercentage;
        
    }
}