using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.PersonalizedInterfaces;
using Fire_Emblem_Common.Models;

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
        Unit skillOwner = GetSkillOwner(roundInfo);
        
        return _analyzedUnit switch
        {
            UnitRole.Unit => _requiredWeaponTypes.Contains(skillOwner.Weapon),
            UnitRole.Rival => _requiredWeaponTypes.Contains(skillOwner.ActualOpponent.Weapon),
            _ => false
        };
    }
}