using Fire_Emblem_Common.Conditions;
namespace Fire_Emblem_Common.ConditionEvaluators;

public class AndConditionEvaluator : ConditionEvaluator
{
    public AndConditionEvaluator(List<Condition> conditions) : base(conditions) { }

    public override bool AreConditionsSatisfied(RoundInfo roundInfo)
    {
        return _conditions.All(condition => condition.IsConditionSatisfied(roundInfo));
    }
}