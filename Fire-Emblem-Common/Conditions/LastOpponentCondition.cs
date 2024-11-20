using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Conditions;

public class LastOpponentCondition:Condition
{
    public override bool IsConditionSatisfied(RoundInfo roundInfo)
    {
        return roundInfo.SkillOwner.LastOpponent == roundInfo.Rival;
    }
}