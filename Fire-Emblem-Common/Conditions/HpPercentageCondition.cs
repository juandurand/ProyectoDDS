namespace Fire_Emblem_Common.Conditions;

public class HpPercentageCondition:Condition
{
    private readonly double _requiredPercentage;
    private readonly string _analyzedUnit;
    
    public HpPercentageCondition(string skillOwnerName, double requiredPercentage, string analyzedUnit) 
        :base(skillOwnerName)
    {
        _analyzedUnit = analyzedUnit;
        _requiredPercentage = requiredPercentage;
    }
    
    public override bool IsConditionSatisfied(Dictionary<string, object> roundInfo)
    {
        (Unit unit, Unit rival) = GetUnits(roundInfo);
        
        if (_analyzedUnit == "Unit")
        {
            return unit.Hp.GetHpPercentage() <= _requiredPercentage;
        }
        return rival.Hp.GetHpPercentage() >= _requiredPercentage;
        
    }
}