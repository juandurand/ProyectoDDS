namespace Fire_Emblem_Common.EDDs.Models;

public class RoundInfo
{
    public readonly Unit Attacker;
    public readonly Unit Defender;
    public Unit SkillOwner;
    public Unit Rival;

    public RoundInfo(Unit attacker, Unit defender)
    {
        Attacker = attacker;
        Defender = defender;
    }
    
    public void SetCurrentSkillOwnerAndRival(Unit skillOwner, Unit rival)
    {
        SkillOwner = skillOwner;
        Rival = rival;
    }
}