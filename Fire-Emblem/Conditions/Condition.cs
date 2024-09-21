namespace Fire_Emblem.Conditions;

public abstract class Condition
{
    public abstract bool IsConditionSatisfied(Dictionary<string, object> roundInfo);
}