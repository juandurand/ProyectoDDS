using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Models;
using Fire_Emblem_Common.Helpers;

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
        Unit skillOwner = GetSkillOwner(roundInfo);
        
        return UnitHelper.GetTotalStat(skillOwner, _skillOwnerStat, AttackType.None) >= 
               _requiredDifference + UnitHelper.GetTotalStat(skillOwner.ActualOpponent, _rivalStat, AttackType.None);
    }
}