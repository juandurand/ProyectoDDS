namespace Fire_Emblem_Common.Conditions;

public class ManRivalCondition:Condition
{
    public override bool IsConditionSatisfied(Dictionary<string, object> roundInfo, string unitOwnerName)
    {
        (Unit unit, Unit rival) = GetUnits(roundInfo, unitOwnerName);
        return rival.Gender == "Male";
    }
}