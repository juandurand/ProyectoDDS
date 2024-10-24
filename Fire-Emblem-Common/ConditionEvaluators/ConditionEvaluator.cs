using Fire_Emblem_Common.PersonalizedInterfaces;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.ConditionEvaluators;

public abstract class ConditionEvaluator
{
    protected readonly ConditionList Conditions;

    protected ConditionEvaluator(ConditionList conditions)
    {
        Conditions = conditions;
    }

    public abstract bool AreConditionsSatisfied(RoundInfo roundInfo);
}