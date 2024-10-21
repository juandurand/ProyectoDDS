namespace Fire_Emblem_Common.Conditions;
using Fire_Emblem_Common.PersonalizedInterfaces;

public class LastOpponentCondition:Condition
{
    public override bool IsConditionSatisfied(RoundInfo roundInfo)
    {
        (Unit starter, Unit rival, Unit skillOwner) = GetUnits(roundInfo);

        return skillOwner.LastOpponent == rival;
    }
}