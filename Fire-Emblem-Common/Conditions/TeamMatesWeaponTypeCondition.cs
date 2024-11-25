using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.PersonalizedInterfaces;
using Fire_Emblem_Common.Models;

namespace Fire_Emblem_Common.Conditions;

public class TeamMatesWeaponTypeCondition:Condition
{
    private readonly EnumList<WeaponType> _requiredWeaponTypes;
    
    public TeamMatesWeaponTypeCondition(EnumList<WeaponType> requiredWeaponTypes)
    {
        _requiredWeaponTypes = requiredWeaponTypes;
    }
    
    public override bool IsConditionSatisfied(RoundInfo roundInfo)
    {
        Unit skillOwner = GetSkillOwner(roundInfo);
        
        foreach (Unit unit in skillOwner.Team)
        {
            if (_requiredWeaponTypes.Contains(unit.Weapon))
            {
                return true;
            }
        }
        return false;
    }
}