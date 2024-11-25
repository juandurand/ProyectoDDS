using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Models;

namespace Fire_Emblem_Common.Conditions;

public class FirstAttackCondition:Condition
{
    private readonly UnitRole _analyzedUnit;
    
    public FirstAttackCondition(UnitRole analyzedUnit)
    {
        _analyzedUnit = analyzedUnit;
    }
    
    public override bool IsConditionSatisfied(RoundInfo roundInfo)
    {
        Unit skillOwner = GetSkillOwner(roundInfo);
        
        return _analyzedUnit switch
        {
            UnitRole.Unit => roundInfo.Attacker == skillOwner,
            UnitRole.Rival => roundInfo.Attacker != skillOwner,
            _ => false
        };
    }

}