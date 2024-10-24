using Fire_Emblem_Common.PersonalizedInterfaces;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.ConditionEvaluators;

public class AndConditionEvaluator : ConditionEvaluator
{
    public AndConditionEvaluator(ConditionList conditions) : base(conditions) { }

    public override bool AreConditionsSatisfied(RoundInfo roundInfo)
    {
        return Conditions.All(condition => condition.IsConditionSatisfied(roundInfo));
    }
}