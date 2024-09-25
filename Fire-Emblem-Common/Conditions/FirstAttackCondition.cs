namespace Fire_Emblem_Common.Conditions;

public class FirstAttackCondition:Condition
{
    private readonly string _analyzedUnit;
    
    public FirstAttackCondition(string analyzedUnit)
    {
        _analyzedUnit = analyzedUnit;
    }
    
    public override bool IsConditionSatisfied(Dictionary<string, Unit> roundInfo)
    {
        (Unit starter, Unit rival, Unit skillOwner) = GetUnits(roundInfo);
        
        if (_analyzedUnit == "Unit")
        {
            return starter == skillOwner;
        }
        return starter != skillOwner;
    }
}