using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.PersonalizedInterfaces;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Conditions;

public class WeaponTypeCondition:Condition
{
    private readonly UnitRole _analyzedUnit;
    private readonly EnumList<WeaponType> _requiredWeaponTypes;
    
    public WeaponTypeCondition(UnitRole analyzedUnit, EnumList<WeaponType> requiredWeaponTypes)
    {
        _analyzedUnit = analyzedUnit;
        _requiredWeaponTypes = requiredWeaponTypes;
    }
    
    public override bool IsConditionSatisfied(RoundInfo roundInfo)
    { 
        if (_analyzedUnit == UnitRole.Unit)
        {
            return _requiredWeaponTypes.Contains(roundInfo.SkillOwner.Weapon);
        }

        if (_analyzedUnit == UnitRole.Rival)
        {
            return _requiredWeaponTypes.Contains(roundInfo.Rival.Weapon);
        }

        return false;
    }
}