namespace Fire_Emblem_Common.Conditions;

public class LastOpponentCondition:Condition
{
    public override bool IsConditionSatisfied(Dictionary<string, object> roundInfo, string unitOwnerName)
    {
        (Unit unit, Unit rival) = GetUnits(roundInfo, unitOwnerName);

        return unit.LastOpponent.PersonalizedName == rival.PersonalizedName;
    }
}