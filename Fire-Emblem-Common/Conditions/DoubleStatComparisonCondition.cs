using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Models;
using Fire_Emblem_Common.Helpers;

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
        Unit skillOwner = GetSkillOwner(roundInfo);
        
        return UnitHelper.GetTotalStat(skillOwner, _firstSkillOwnerStat, AttackType.None) + 
               UnitHelper.GetTotalStat(skillOwner, _secondSkillOwnerStat, AttackType.None) >= _requiredDifference + 
               UnitHelper.GetTotalStat(skillOwner.ActualOpponent, _firstRivalStat, AttackType.None) + 
               UnitHelper.GetTotalStat(skillOwner.ActualOpponent, _secondRivalStat, AttackType.None);
    }
}