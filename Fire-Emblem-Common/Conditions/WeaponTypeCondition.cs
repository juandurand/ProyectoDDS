namespace Fire_Emblem_Common.Conditions;

public class WeaponTypeCondition:Condition
{
    private readonly UnitRole _analyzedUnit;
    private readonly List<WeaponType> _requiredWeaponTypes;
    
    public WeaponTypeCondition(UnitRole analyzedUnit, List<WeaponType> requiredWeaponTypes)
    {
        _analyzedUnit = analyzedUnit;
        _requiredWeaponTypes = requiredWeaponTypes;
    }
    
    public override bool IsConditionSatisfied(RoundInfo roundInfo)
    {
        (Unit starter, Unit rival, Unit skillOwner) = GetUnits(roundInfo);
        
        if (_analyzedUnit == UnitRole.Unit)
        {
            return _requiredWeaponTypes.Contains(skillOwner.Weapon);
        }
        return _requiredWeaponTypes.Contains(rival.Weapon);
    }
}