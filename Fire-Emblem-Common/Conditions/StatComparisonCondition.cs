using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;
using Fire_Emblem_Common.EDDs.Managers;

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
        return UnitManager.GetTotalStat(roundInfo.SkillOwner, _skillOwnerStat, AttackType.None) >= 
               _requiredDifference + UnitManager.GetTotalStat(roundInfo.Rival, _rivalStat, AttackType.None);
    }
}