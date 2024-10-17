namespace Fire_Emblem_Common.Conditions;

public class ChaosStyleCondition:Condition
{
    private readonly List<WeaponType> _requiredWeaponTypes = new List<WeaponType>
    {
        WeaponType.Sword,
        WeaponType.Bow,
        WeaponType.Lance,
        WeaponType.Axe
    };
    
    public override bool IsConditionSatisfied(RoundInfo roundInfo)
    {
        (Unit starter, Unit rival, Unit skillOwner) = GetUnits(roundInfo);
        
        if (starter != skillOwner)
        {
            return false;
        }
        
        return IsChaosStyleConditionSatisfied(starter, rival) || IsChaosStyleConditionSatisfied(rival, starter);
    }

    private bool IsChaosStyleConditionSatisfied(Unit unit, Unit rival)
    {
        return _requiredWeaponTypes.Contains(unit.Weapon) && rival.Weapon == WeaponType.Magic;
    }
}