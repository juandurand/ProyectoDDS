using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.PersonalizedInterfaces;
using Fire_Emblem_Common.Models;

namespace Fire_Emblem_Common.Conditions;

public class ChaosStyleCondition : Condition
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
        Unit skillOwner = GetSkillOwner(roundInfo);
        
        return IsChaosStyleConditionSatisfied(skillOwner, skillOwner.ActualOpponent) || 
               IsChaosStyleConditionSatisfied(skillOwner.ActualOpponent, skillOwner);
    }

    private bool IsChaosStyleConditionSatisfied(Unit unit, Unit rival)
    {
        return _requiredWeaponTypes.Contains(unit.Weapon) && rival.Weapon == WeaponType.Magic;
    }
}