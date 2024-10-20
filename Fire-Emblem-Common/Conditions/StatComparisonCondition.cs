using Fire_Emblem_Common.Enums;

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
        
        return UnitController.GetTotalStat(skillOwner, _skillOwnerStat, AttackType.None) >= _requiredDifference + UnitController.GetTotalStat(rival, _rivalStat, AttackType.None);
    }
}