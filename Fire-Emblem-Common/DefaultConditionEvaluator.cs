using Fire_Emblem_Common.Conditions;
namespace Fire_Emblem_Common;

public class DefaultConditionEvaluator : ConditionEvaluator
{
    public DefaultConditionEvaluator(List<Condition> conditions) : base(conditions) { }

    public override bool AreConditionsSatisfied(RoundInfo roundInfo)
    {
        return _conditions.Count == 0 || _conditions[0].IsConditionSatisfied(roundInfo);
    }
}