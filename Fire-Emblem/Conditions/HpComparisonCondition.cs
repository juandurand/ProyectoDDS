using Fire_Emblem_Common;
namespace Fire_Emblem.Conditions;

public class HpComparisonCondition:Condition
{
    private readonly int _requiredDifference;
    
    public HpComparisonCondition(int requiredDifference)
    {
        _requiredDifference = requiredDifference;
    }
    
    public override bool IsConditionSatisfied(Dictionary<string, object> roundInfo)
    {
        Unit unit = roundInfo["Unit"] as Unit;
        Unit rival = roundInfo["Rival"] as Unit;
        
        return unit.ActualHp >= _requiredDifference + rival.ActualHp;
    }
}