using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Conditions;

public class ManRivalCondition:Condition
{
    public override bool IsConditionSatisfied(RoundInfo roundInfo)
    {
        return roundInfo.Rival.Gender == "Male";
    }
}