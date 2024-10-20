using Fire_Emblem_Common.PersonalizedInterfaces;

namespace Fire_Emblem_Common.ConditionEvaluators;

public abstract class ConditionEvaluator
{
    protected readonly ConditionList _conditions;

    protected ConditionEvaluator(ConditionList conditions)
    {
        _conditions = conditions;
    }

    public abstract bool AreConditionsSatisfied(RoundInfo roundInfo);
}