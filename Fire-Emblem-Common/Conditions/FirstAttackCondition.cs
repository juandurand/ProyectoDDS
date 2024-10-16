namespace Fire_Emblem_Common.Conditions;

public class FirstAttackCondition:Condition
{
    private readonly UnitRole _analyzedUnit;
    
    public FirstAttackCondition(UnitRole analyzedUnit)
    {
        _analyzedUnit = analyzedUnit;
    }
    
    public override bool IsConditionSatisfied(RoundInfo roundInfo)
    {
        (Unit starter, Unit rival, Unit skillOwner) = GetUnits(roundInfo);
        
        if (_analyzedUnit == UnitRole.Unit)
        {
            return starter == skillOwner;
        }
        return starter != skillOwner;
    }
}