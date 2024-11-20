using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Conditions;

public abstract class Condition
{
    public abstract bool IsConditionSatisfied(RoundInfo roundInfo);
}