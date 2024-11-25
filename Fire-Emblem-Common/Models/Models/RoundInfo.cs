namespace Fire_Emblem_Common.EDDs.Models;

public class RoundInfo
{
    public readonly Unit Attacker;
    public readonly Unit Defender;
    public Unit SkillOwner;

    public RoundInfo(Unit attacker, Unit defender)
    {
        Attacker = attacker;
        Defender = defender;
    }
    
    public void SetCurrentSkillOwner(Unit skillOwner)
    {
        SkillOwner = skillOwner;
    }
}