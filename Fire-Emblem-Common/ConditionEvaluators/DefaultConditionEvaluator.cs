using Fire_Emblem_Common.PersonalizedInterfaces;

namespace Fire_Emblem_Common.ConditionEvaluators;

public class DefaultConditionEvaluator : ConditionEvaluator
{
    public DefaultConditionEvaluator(ConditionList conditions) : base(conditions) { }

    public override bool AreConditionsSatisfied(RoundInfo roundInfo)
    {
        return Conditions.Count == 0 || Conditions.Get(0).IsConditionSatisfied(roundInfo);
    }
}