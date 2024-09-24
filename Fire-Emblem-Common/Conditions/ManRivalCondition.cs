namespace Fire_Emblem_Common.Conditions;

public class ManRivalCondition:Condition
{
    public ManRivalCondition(string skillOwnerName):base(skillOwnerName){}
    public override bool IsConditionSatisfied(Dictionary<string, object> roundInfo)
    {
        (Unit unit, Unit rival) = GetUnits(roundInfo);
        return rival.Gender == "Male";
    }
}