using Fire_Emblem_Common.PersonalizedInterfaces;

namespace Fire_Emblem_Common.ConditionEvaluators;

public class DefaultConditionEvaluator : ConditionEvaluator
{
    public DefaultConditionEvaluator(ConditionList conditions) : base(conditions) { }

    public override bool AreConditionsSatisfied(RoundInfo roundInfo)
    {
        return _conditions.Count == 0 || _conditions.Get(0).IsConditionSatisfied(roundInfo);
    }
}