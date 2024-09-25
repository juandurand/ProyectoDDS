namespace Fire_Emblem_Common.Conditions;

public class ChaosStyleCondition:Condition
{
    public override bool IsConditionSatisfied(Dictionary<string, Unit> roundInfo)
    {
        (Unit starter, Unit rival, Unit skillOwner) = GetUnits(roundInfo);
        
        if (starter != skillOwner)
        {
            return false;
        }
        
        return IsChaosStyleConditionSatisfied(starter, rival) || IsChaosStyleConditionSatisfied(rival, starter);
    }

    private bool IsChaosStyleConditionSatisfied(Unit unit, Unit rival)
    {
        List<string> requiredWeaponType = new List<string> { "Sword", "Bow", "Lance", "Axe" };
        if (requiredWeaponType.Contains(unit.Weapon) && rival.Weapon == "Magic")
        {
            return true;
        }
        return false;
    }
}