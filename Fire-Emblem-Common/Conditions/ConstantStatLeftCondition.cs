using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;
using Fire_Emblem_Common.EDDs.Managers;

namespace Fire_Emblem_Common.Conditions;

public class ConstantStatLeftCondition:Condition
{
    private readonly int _requireLeftValue;
    private readonly StatType _skillOwnerStat;
    
    public ConstantStatLeftCondition(int requireLeftValue, StatType skillOwnerStat) 
    {
        _requireLeftValue = requireLeftValue;
        _skillOwnerStat = skillOwnerStat;
    }
    
    public override bool IsConditionSatisfied(RoundInfo roundInfo)
    {
        (Unit starter, Unit rival, Unit skillOwner) = GetUnits(roundInfo);
        
        return UnitManager.GetTotalStat(skillOwner, _skillOwnerStat, AttackType.None) >= _requireLeftValue;
    }
}