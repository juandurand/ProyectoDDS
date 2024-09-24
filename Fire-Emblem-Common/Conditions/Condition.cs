namespace Fire_Emblem_Common.Conditions;

public abstract class Condition
{
    private readonly string _skillOwnerName;
    protected Condition(string skillOwnerName)
    {
        _skillOwnerName = skillOwnerName;
    }
    public abstract bool IsConditionSatisfied(Dictionary<string, object> roundInfo);
    
    protected (Unit unit, Unit rival) GetUnits(Dictionary<string, object> roundInfo)
    {
        Unit unit = roundInfo["Unit"] as Unit;
        Unit rival = roundInfo["Rival"] as Unit;

        if (unit.PersonalizedName != _skillOwnerName)
        {
            return (rival, unit);
        }
        return (unit, rival);
    }
}