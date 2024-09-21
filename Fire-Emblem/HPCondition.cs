using Fire_Emblem_Common;
namespace Fire_Emblem;

public class HPPercentageCondition:Condition
{
    private readonly double _requiredPercentage;
    private readonly string _unit;
    
    public HPCondition(double requiredPercentage, string unit)
    {
        _unit = unit;
        _requiredPercentage = requiredPercentage;
    }
    
    public override bool IsConditionSatisfied(Dictionary<string, object> roundInfo)
    {
        Unit unit = roundInfo["Unit"] as Unit;
        Unit rival = roundInfo["Rival"] as Unit;
        
        if (_unit == "Unit")
        {
            return unit.GetHPPercentage() <= _requiredPercentage;
        }
        return rival.GetHPPercentage() <= _requiredPercentage;
        
    }
}