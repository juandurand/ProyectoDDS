using Fire_Emblem_Common.Conditions;
namespace Fire_Emblem_Common.ConditionEvaluators;

public class OrConditionEvaluator : ConditionEvaluator
{
    public OrConditionEvaluator(List<Condition> conditions) : base(conditions) { }

    public override bool AreConditionsSatisfied(RoundInfo roundInfo)
    {
        return _conditions.Any(condition => condition.IsConditionSatisfied(roundInfo));
    }
}