using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.PersonalizedInterfaces;
using Fire_Emblem_Common.EDDs.Models;

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
        (Unit starter, Unit rival, Unit skillOwner) = GetUnits(roundInfo);
        
        foreach (Unit unit in roundInfo.SkillOwner.Team)
        {
            if (_requiredWeaponTypes.Contains(unit.Weapon))
            {
                return true;
            }
        }
        return false;
    }
}