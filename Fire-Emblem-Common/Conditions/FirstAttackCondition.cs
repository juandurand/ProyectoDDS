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
        if (_analyzedUnit == UnitRole.Unit)
        {
            return roundInfo.Attacker == roundInfo.SkillOwner;
        }
        
        if (_analyzedUnit == UnitRole.Rival)
        {
            return roundInfo.Attacker != roundInfo.SkillOwner;
        }
        
        return false;
    }
}