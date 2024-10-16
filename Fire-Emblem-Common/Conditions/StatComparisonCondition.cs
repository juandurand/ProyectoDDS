namespace Fire_Emblem_Common.Conditions;

public class StatComparisonCondition:Condition
{
    private readonly int _requiredDifference;
    private readonly StatType _skillOwnerStat;
    private readonly StatType _rivalStat;
    
    public StatComparisonCondition(int requiredDifference, StatType skillOwnerStat, StatType rivalStat) 
    {
        _requiredDifference = requiredDifference;
        _skillOwnerStat = skillOwnerStat;
        _rivalStat = rivalStat;
    }
    
    public override bool IsConditionSatisfied(RoundInfo roundInfo)
    {
        (Unit starter, Unit rival, Unit skillOwner) = GetUnits(roundInfo);
        
        return skillOwner.GetTotalStat(_skillOwnerStat, AttackType.None) >= _requiredDifference + rival.GetTotalStat(_rivalStat, AttackType.None);
    }
}