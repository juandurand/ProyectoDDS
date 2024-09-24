namespace Fire_Emblem_Common.Conditions;

public class FirstAttackCondition:Condition
{
    private readonly string _analyzedUnit;
    private readonly string _skillOwnerName;
    
    public FirstAttackCondition(string skillOwnerName, string analyzedUnit)
        :base(skillOwnerName)
    {
        _analyzedUnit = analyzedUnit;
    }
    
    public override bool IsConditionSatisfied(Dictionary<string, object> roundInfo)
    {
        Unit unit = roundInfo["Unit"] as Unit;
        Unit rival = roundInfo["Rival"] as Unit;
        
        if (_analyzedUnit == "Unit")
        {
            return unit.PersonalizedName == _skillOwnerName;
        }
        return rival.PersonalizedName == _skillOwnerName;
    }
}