namespace Fire_Emblem_Common.Conditions;

public class HpComparisonCondition:Condition
{
    private readonly int _requiredDifference;
    
    public HpComparisonCondition(int requiredDifference)
    {
        _requiredDifference = requiredDifference;
    }
    
    public override bool IsConditionSatisfied(Dictionary<string, object> roundInfo, string unitOwnerName)
    {
        (Unit unit, Unit rival) = GetUnits(roundInfo, unitOwnerName);
        
        return unit.ActualHp >= _requiredDifference + rival.ActualHp;
    }
}