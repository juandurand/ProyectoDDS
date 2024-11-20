using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;
using Fire_Emblem_Common.EDDs.Managers;

namespace Fire_Emblem_Common.Conditions;

public class BaseStatComparisonCondition:Condition
{
    private readonly int _requiredDifference;
    private readonly StatType _skillOwnerStat;
    private readonly StatType _rivalStat;
    
    public BaseStatComparisonCondition(int requiredDifference, StatType skillOwnerStat, StatType rivalStat) 
    {
        _requiredDifference = requiredDifference;
        _skillOwnerStat = skillOwnerStat;
        _rivalStat = rivalStat;
    }
    
    public override bool IsConditionSatisfied(RoundInfo roundInfo)
    {
        return UnitManager.GetBaseValue(roundInfo.SkillOwner, _skillOwnerStat) >= 
               _requiredDifference + UnitManager.GetBaseValue(roundInfo.Rival, _rivalStat);
    }
}