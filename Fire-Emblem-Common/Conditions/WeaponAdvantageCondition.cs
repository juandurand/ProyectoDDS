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
        (Unit starter, Unit rival, Unit skillOwner) = GetUnits(roundInfo);
        
        if (_analyzedUnit == UnitRole.Unit)
        {
            return WeaponTriangle.CalculateWtb(skillOwner.Weapon, rival.Weapon) == 1.2;
        }
        return WeaponTriangle.CalculateWtb(rival.Weapon, skillOwner.Weapon) == 1.2;
    }
}