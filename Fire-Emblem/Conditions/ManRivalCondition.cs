using Fire_Emblem_Common;
namespace Fire_Emblem.Conditions;

public class ManRivalCondition:Condition
{
    public override bool IsConditionSatisfied(Dictionary<string, object> roundInfo)
    {
        Unit rival = roundInfo["Rival"] as Unit;
        return rival.Gender == "Male";
    }
}