namespace Fire_Emblem_Common.Conditions;

public class HpPercentageCondition:Condition
{
    private readonly double _requiredPercentage;
    private readonly string _analyzedUnit;
    
    public HpPercentageCondition(double requiredPercentage, string analyzedUnit) 
    {
        _analyzedUnit = analyzedUnit;
        _requiredPercentage = requiredPercentage;
    }
    
    public override bool IsConditionSatisfied(Dictionary<string, Unit> roundInfo)
    {
        (Unit starter, Unit rival, Unit skillOwner) = GetUnits(roundInfo);
        
        if (_analyzedUnit == "Unit")
        {
            return skillOwner.Hp.GetHpPercentage() <= _requiredPercentage;
        }
        return rival.Hp.GetHpPercentage() >= _requiredPercentage;
        
    }
}