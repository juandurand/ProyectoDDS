using Fire_Emblem_Common.PersonalizedInterfaces;
using Fire_Emblem_Common.Models;

namespace Fire_Emblem_Common.ConditionEvaluators;

public class AndConditionEvaluator : ConditionEvaluator
{
    private readonly ConditionList _conditions;

    public AndConditionEvaluator(ConditionList conditions)
    {
        _conditions = conditions;
    }

    public override bool AreConditionsSatisfied(RoundInfo roundInfo)
    {
        return _conditions.All(condition => condition.IsConditionSatisfied(roundInfo));
    }
}