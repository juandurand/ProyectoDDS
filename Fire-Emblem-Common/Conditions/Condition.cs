namespace Fire_Emblem_Common.Conditions;

public abstract class Condition
{
    public abstract bool IsConditionSatisfied(Dictionary<string, object> roundInfo, string unitOwnerName);
    
    protected (Unit unit, Unit rival) GetUnits(Dictionary<string, object> roundInfo, string unitOwnerName)
    {
        Unit unit = roundInfo["Unit"] as Unit;
        Unit rival = roundInfo["Rival"] as Unit;

        if (unit.Name != unitOwnerName)
        {
            return (rival, unit);
        }
        return (unit, rival);
    }
}