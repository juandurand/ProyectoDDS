using Fire_Emblem_Common.PersonalizedInterfaces;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Conditions;

public abstract class Condition
{
    public abstract bool IsConditionSatisfied(RoundInfo roundInfo);
    
    protected (Unit unit, Unit rival, Unit skillOwner) GetUnits(RoundInfo roundInfo)
    {
        Unit starter = roundInfo.Attacker;
        Unit rival = roundInfo.Rival;
        Unit skillOwner = roundInfo.SkillOwner;
        return (starter, rival, skillOwner);
    }
}