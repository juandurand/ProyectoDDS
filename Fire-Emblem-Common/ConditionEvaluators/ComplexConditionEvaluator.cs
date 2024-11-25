using Fire_Emblem_Common.PersonalizedInterfaces;
using Fire_Emblem_Common.Models;

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
        bool firstConditionListSatisfied = _firstConditionsList.All(
                                            condition => condition.IsConditionSatisfied(roundInfo));
        bool secondConditionListSatisfied = _secondConditionsList.All(
                                            condition => condition.IsConditionSatisfied(roundInfo));
        
        return firstConditionListSatisfied || secondConditionListSatisfied;
    }
}