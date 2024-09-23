namespace Fire_Emblem_Common.Conditions;

public class WeaponTypeCondition:Condition
{
    private readonly string _analyzedUnit;
    private readonly List<string> _requiredWeaponType;
    
    public WeaponTypeCondition(string analyzedUnit, List<string> requiredWeaponType)
    {
        _analyzedUnit = analyzedUnit;
        _requiredWeaponType = requiredWeaponType;
    }
    
    public override bool IsConditionSatisfied(Dictionary<string, object> roundInfo, string unitOwnerName)
    {
        (Unit unit, Unit rival) = GetUnits(roundInfo, unitOwnerName);
        
        if (_analyzedUnit == "Unit")
        {
            return _requiredWeaponType.Contains(unit.Weapon);
        }
        return _requiredWeaponType.Contains(rival.Weapon);
    }
}