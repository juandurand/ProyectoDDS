namespace Fire_Emblem_Common.Conditions;

public class LastOpponentCondition:Condition
{
    public LastOpponentCondition(string skillOwnerName):base(skillOwnerName){}
    public override bool IsConditionSatisfied(Dictionary<string, object> roundInfo)
    {
        (Unit unit, Unit rival) = GetUnits(roundInfo);

        return unit.LastOpponent.PersonalizedName == rival.PersonalizedName;
    }
}