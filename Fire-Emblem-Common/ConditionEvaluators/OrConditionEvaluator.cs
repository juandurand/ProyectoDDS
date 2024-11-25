using Fire_Emblem_Common.PersonalizedInterfaces;
using Fire_Emblem_Common.Models;

namespace Fire_Emblem_Common.ConditionEvaluators;

public class OrConditionEvaluator : ConditionEvaluator
{
    private readonly ConditionList _conditions;

    public OrConditionEvaluator(ConditionList conditions)
    {
        _conditions = conditions;
    }

    public override bool AreConditionsSatisfied(RoundInfo roundInfo)
    {
        return _conditions.Any(condition => condition.IsConditionSatisfied(roundInfo));
    }
}