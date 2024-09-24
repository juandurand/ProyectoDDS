namespace Fire_Emblem_Common.Conditions;

public class HpComparisonCondition:Condition
{
    private readonly int _requiredDifference;
    
    public HpComparisonCondition(string skillOwnerName, int requiredDifference) 
        :base(skillOwnerName)
    {
        _requiredDifference = requiredDifference;
    }
    
    public override bool IsConditionSatisfied(Dictionary<string, object> roundInfo)
    {
        (Unit unit, Unit rival) = GetUnits(roundInfo);
        
        return unit.Hp.ActualHpValue >= _requiredDifference + rival.Hp.ActualHpValue;
    }
}