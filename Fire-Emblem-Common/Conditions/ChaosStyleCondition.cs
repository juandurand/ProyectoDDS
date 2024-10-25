using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.PersonalizedInterfaces;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Conditions;

public class ChaosStyleCondition:Condition
{
    private readonly EnumList<WeaponType> _requiredWeaponTypes = new EnumList<WeaponType>(
        new List<WeaponType> 
    {
        WeaponType.Sword,
        WeaponType.Bow,
        WeaponType.Lance,
        WeaponType.Axe
    });
    
    public override bool IsConditionSatisfied(RoundInfo roundInfo)
    {
        (Unit starter, Unit rival, Unit skillOwner) = GetUnits(roundInfo);
        
        if (starter != skillOwner)
        {
            return false;
        }
        
        return IsChaosStyleConditionSatisfied(starter, rival) || 
               IsChaosStyleConditionSatisfied(rival, starter);
    }

    private bool IsChaosStyleConditionSatisfied(Unit unit, Unit rival)
    {
        return _requiredWeaponTypes.Contains(unit.Weapon) && rival.Weapon == WeaponType.Magic;
    }
}