using Fire_Emblem_Common.Conditions;
namespace Fire_Emblem_Common;

public class ConditionEvaluator
{
    private readonly List<Condition> _conditions;
    private readonly string _conditionsConnector;

    public ConditionEvaluator(List<Condition> conditions, string conditionsConnector)
    {
        _conditions = conditions;
        _conditionsConnector = conditionsConnector;
    }

    public bool AreConditionsSatisfied(Dictionary<string, Unit> roundInfo)
    {
        if (_conditionsConnector == "Or")
        {
            return OrCondition(roundInfo);
        }
        if (_conditionsConnector == "And")
        {
            return AndCondition(roundInfo);
        }
        return DefaultCondition(roundInfo);
    }

    private bool OrCondition(Dictionary<string, Unit> roundInfo)
    {
        return _conditions.Any(condition => condition.IsConditionSatisfied(roundInfo));
    }

    private bool AndCondition(Dictionary<string, Unit> roundInfo)
    {
        return _conditions.All(condition => condition.IsConditionSatisfied(roundInfo));
    }

    private bool DefaultCondition(Dictionary<string, Unit> roundInfo)
    {
        return _conditions.Count == 0 || _conditions[0].IsConditionSatisfied(roundInfo);
    }
}
