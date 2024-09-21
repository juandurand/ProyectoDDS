using Fire_Emblem_Common;
namespace Fire_Emblem.Conditions;

public class LastOpponentCondition:Condition
{
    public override bool IsConditionSatisfied(Dictionary<string, object> roundInfo)
    {
        Unit unit = roundInfo["Unit"] as Unit;
        Unit rival = roundInfo["Rival"] as Unit;

        return unit.LastOpponent.Name == rival.Name;
    }
}