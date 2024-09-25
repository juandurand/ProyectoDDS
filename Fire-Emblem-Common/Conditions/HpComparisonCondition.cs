namespace Fire_Emblem_Common.Conditions;

public class HpComparisonCondition:Condition
{
    private readonly int _requiredDifference;
    
    public HpComparisonCondition(int requiredDifference) 
    {
        _requiredDifference = requiredDifference;
    }
    
    public override bool IsConditionSatisfied(Dictionary<string, Unit> roundInfo)
    {
        (Unit starter, Unit rival, Unit skillOwner) = GetUnits(roundInfo);
        
        return skillOwner.Hp.ActualHpValue >= _requiredDifference + rival.Hp.ActualHpValue;
    }
}