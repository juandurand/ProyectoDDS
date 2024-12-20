using Fire_Emblem_Common.PersonalizedInterfaces;
using Fire_Emblem_Common.Models;

namespace Fire_Emblem_Common.ConditionEvaluators;

public class DefaultConditionEvaluator : ConditionEvaluator
{
    
    private readonly ConditionList _conditions;

    public DefaultConditionEvaluator(ConditionList conditions)
    {
        _conditions = conditions;
    }

    public override bool AreConditionsSatisfied(RoundInfo roundInfo)
    {
        return _conditions.Count == 0 || _conditions.GetCondition(0).IsConditionSatisfied(roundInfo);
    }
}