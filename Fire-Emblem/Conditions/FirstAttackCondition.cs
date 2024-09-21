using Fire_Emblem_Common;
namespace Fire_Emblem.Conditions;

public class FirstAttackCondition:Condition
{
    private readonly string _analyzedUnit;
    private readonly string _skillOwnerName;
    
    public FirstAttackCondition(string analyzedUnit, string skillOwnerName)
    {
        _analyzedUnit = analyzedUnit;
        _skillOwnerName = skillOwnerName;
    }
    
    public override bool IsConditionSatisfied(Dictionary<string, object> roundInfo)
    {
        Unit unit = roundInfo["Unit"] as Unit;
        Unit rival = roundInfo["Rival"] as Unit;
        
        if (_analyzedUnit == "Unit")
        {
            return unit.Name == _skillOwnerName;
        }
        return rival.Name == _skillOwnerName;
    }
}