using Fire_Emblem_Common.Models;

namespace Fire_Emblem_Common.Conditions;

public abstract class Condition
{
    protected Unit GetSkillOwner(RoundInfo roundInfo)
    {
        return roundInfo.SkillOwner;
    }
    
    public abstract bool IsConditionSatisfied(RoundInfo roundInfo);
}