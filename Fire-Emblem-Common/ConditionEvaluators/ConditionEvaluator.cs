using Fire_Emblem_Common.Models;

namespace Fire_Emblem_Common.ConditionEvaluators;

public abstract class ConditionEvaluator
{
    public abstract bool AreConditionsSatisfied(RoundInfo roundInfo);
}