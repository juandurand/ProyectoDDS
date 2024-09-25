namespace Fire_Emblem_Common.Conditions;

public abstract class Condition
{
    public abstract bool IsConditionSatisfied(Dictionary<string, Unit> roundInfo);
    
    protected (Unit unit, Unit rival, Unit skillOwner) GetUnits(Dictionary<string, Unit> roundInfo)
    {
        Unit starter = roundInfo["Attacker"] as Unit;
        Unit rival = roundInfo["Rival"] as Unit;
        Unit skillOwner = roundInfo["SkillOwner"] as Unit;
        return (starter, rival, skillOwner);
    }
}