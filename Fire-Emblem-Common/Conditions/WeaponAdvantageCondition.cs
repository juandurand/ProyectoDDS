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
        (Unit starter, Unit rival, Unit skillOwner) = GetUnits(roundInfo);
        double advantageValue = 1.2;
        
        if (_analyzedUnit == UnitRole.Unit)
        {
            return WeaponTriangle.CalculateWtb(skillOwner.Weapon, rival.Weapon) == advantageValue;
        }

        if (_analyzedUnit == UnitRole.Rival)
        {
            return WeaponTriangle.CalculateWtb(rival.Weapon, skillOwner.Weapon) == advantageValue;
        }

        return false;
    }
}