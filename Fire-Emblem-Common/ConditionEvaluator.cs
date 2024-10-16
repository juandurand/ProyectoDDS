using Fire_Emblem_Common.Conditions;
namespace Fire_Emblem_Common;

public abstract class ConditionEvaluator
{
    protected readonly List<Condition> _conditions;

    protected ConditionEvaluator(List<Condition> conditions)
    {
        _conditions = conditions;
    }

    public abstract bool AreConditionsSatisfied(RoundInfo roundInfo);
}