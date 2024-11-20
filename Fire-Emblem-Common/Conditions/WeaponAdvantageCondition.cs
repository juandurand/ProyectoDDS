using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Conditions;

public class WeaponAdvantageCondition:Condition
{
    private readonly UnitRole _analyzedUnit;
    
    public WeaponAdvantageCondition(UnitRole analyzedUnit)
    {
        _analyzedUnit = analyzedUnit;
    }
    
    public override bool IsConditionSatisfied(RoundInfo roundInfo)
    {
        double advantageValue = 1.2;
        
        if (_analyzedUnit == UnitRole.Unit)
        {
            return WeaponTriangle.CalculateWtb(roundInfo.SkillOwner.Weapon, roundInfo.Rival.Weapon) == advantageValue;
        }

        if (_analyzedUnit == UnitRole.Rival)
        {
            return WeaponTriangle.CalculateWtb(roundInfo.Rival.Weapon, roundInfo.SkillOwner.Weapon) == advantageValue;
        }

        return false;
    }
}