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

        return _analyzedUnit switch
        {
            UnitRole.Unit => WeaponTriangle.GetWtb(roundInfo.SkillOwner.Weapon, roundInfo.Rival.Weapon) ==
                             advantageValue,
            UnitRole.Rival => WeaponTriangle.GetWtb(roundInfo.Rival.Weapon, roundInfo.SkillOwner.Weapon) ==
                              advantageValue,
            _ => false
        };
    }
}