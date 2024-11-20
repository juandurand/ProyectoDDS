using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;
using Fire_Emblem_Common.EDDs.Managers;

namespace Fire_Emblem_Common.Conditions;

public class DoubleStatComparisonCondition:Condition
{
    private readonly int _requiredDifference;
    private readonly StatType _firstSkillOwnerStat;
    private readonly StatType _secondSkillOwnerStat;
    private readonly StatType _firstRivalStat;
    private readonly StatType _secondRivalStat;
    
    public DoubleStatComparisonCondition(int requiredDifference, StatType firstSkillOwnerStat,
        StatType secondSkillOwnerStat, StatType firstRivalStat, StatType secondRivalStat) 
    {
        _requiredDifference = requiredDifference;
        _firstSkillOwnerStat = firstSkillOwnerStat;
        _secondSkillOwnerStat = secondSkillOwnerStat;
        _firstRivalStat = firstRivalStat;
        _secondRivalStat = secondRivalStat;
    }
    
    public override bool IsConditionSatisfied(RoundInfo roundInfo)
    {
        return UnitManager.GetTotalStat(roundInfo.SkillOwner, _firstSkillOwnerStat, AttackType.None) + 
               UnitManager.GetTotalStat(roundInfo.SkillOwner, _secondSkillOwnerStat, AttackType.None) >= 
               _requiredDifference + UnitManager.GetTotalStat(roundInfo.Rival, _firstRivalStat, AttackType.None) + 
               UnitManager.GetTotalStat(roundInfo.Rival, _secondRivalStat, AttackType.None);
    }
}