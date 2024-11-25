using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Models;

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
        Unit skillOwner = GetSkillOwner(roundInfo);
        double advantageValue = 1.2;

        return _analyzedUnit switch
        {
            UnitRole.Unit => WeaponTriangle.GetWtb(skillOwner.Weapon, skillOwner.ActualOpponent.Weapon) ==
                             advantageValue,
            UnitRole.Rival => WeaponTriangle.GetWtb(skillOwner.ActualOpponent.Weapon, skillOwner.Weapon) ==
                              advantageValue,
            _ => false
        };
    }
}