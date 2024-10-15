namespace Fire_Emblem_Common.Conditions;

public class ManRivalCondition:Condition
{
    public override bool IsConditionSatisfied(RoundInfo roundInfo)
    {
        (Unit starter, Unit rival, Unit skillOwner) = GetUnits(roundInfo);
        
        return rival.Gender == "Male";
    }
}