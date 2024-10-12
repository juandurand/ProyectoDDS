namespace Fire_Emblem_Common.Conditions;

public class StatComparisonCondition:Condition
{
    private readonly int _requiredDifference;
    private readonly string _skillOwnerStat;
    private readonly string _rivalStat;
    
    public StatComparisonCondition(int requiredDifference, string skillOwnerStat, string rivalStat) 
    {
        _requiredDifference = requiredDifference;
        _skillOwnerStat = skillOwnerStat;
        _rivalStat = rivalStat;
    }
    
    public override bool IsConditionSatisfied(Dictionary<string, Unit> roundInfo)
    {
        (Unit starter, Unit rival, Unit skillOwner) = GetUnits(roundInfo);
        
        return skillOwner.GetTotalStat(_skillOwnerStat, "") >= _requiredDifference + rival.GetTotalStat(_rivalStat, "");
    }
}