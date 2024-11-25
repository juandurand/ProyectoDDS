using Fire_Emblem_Common.Models;

namespace Fire_Emblem_Common.Conditions;

public class ManRivalCondition:Condition
{
    public override bool IsConditionSatisfied(RoundInfo roundInfo)
    {
        Unit skillOwner = GetSkillOwner(roundInfo);
        
        return skillOwner.ActualOpponent.Gender == "Male";
    }
}