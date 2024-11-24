using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;

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
        return _analyzedUnit switch
        {
            UnitRole.Unit => roundInfo.Attacker == roundInfo.SkillOwner,
            UnitRole.Rival => roundInfo.Attacker != roundInfo.SkillOwner,
            _ => false
        };
    }

}