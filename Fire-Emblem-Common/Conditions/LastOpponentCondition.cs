using Fire_Emblem_Common.PersonalizedInterfaces;

namespace Fire_Emblem_Common.Conditions;

public class LastOpponentCondition:Condition
{
    public override bool IsConditionSatisfied(RoundInfo roundInfo)
    {
        (Unit starter, Unit rival, Unit skillOwner) = GetUnits(roundInfo);

        return skillOwner.LastOpponent == rival;
    }
}