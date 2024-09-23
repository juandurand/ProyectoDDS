namespace Fire_Emblem_Common.Conditions;

public class ChaosStyleCondition:Condition
{
    private readonly string _skillOwnerName;
    public ChaosStyleCondition(string skillOwnerName)
    {
        _skillOwnerName = skillOwnerName;
    }
    public override bool IsConditionSatisfied(Dictionary<string, object> roundInfo, string unitOwnerName)
    {
        Unit unit = roundInfo["Unit"] as Unit;
        Unit rival = roundInfo["Rival"] as Unit;
        
        if (unit.PersonalizedName != _skillOwnerName)
        {
            return false;
        }

        return IsSatisfied(unit, rival) || IsSatisfied(rival, unit);
    }

    private bool IsSatisfied(Unit unit, Unit rival)
    {
        List<string> requiredWeaponType = new List<string> { "Sword", "Bow", "Lance", "Axe" };
        if (requiredWeaponType.Contains(unit.Weapon) && rival.Weapon == "Magic")
        {
            return true;
        }
        return false;
    }
}