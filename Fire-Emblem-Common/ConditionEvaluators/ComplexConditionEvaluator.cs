using Fire_Emblem_Common.PersonalizedInterfaces;
using Fire_Emblem_Common.EDDs.Models;


namespace Fire_Emblem_Common.ConditionEvaluators;

public class ComplexConditionEvaluator : ConditionEvaluator
{
    private readonly ConditionList _firstConditionsList;
    private readonly ConditionList _secondConditionsList;

    public ComplexConditionEvaluator(ConditionList firstConditionsList, ConditionList secondConditionsList)
    {
        _firstConditionsList = firstConditionsList;
        _secondConditionsList = secondConditionsList;
    }

    public override bool AreConditionsSatisfied(RoundInfo roundInfo)
    {
        bool list1Satisfied = _firstConditionsList.All(condition => condition.IsConditionSatisfied(roundInfo));
        bool list2Satisfied = _secondConditionsList.All(condition => condition.IsConditionSatisfied(roundInfo));
        return list1Satisfied || list2Satisfied;
    }
}