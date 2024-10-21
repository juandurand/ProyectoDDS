namespace Fire_Emblem_Common.PersonalizedInterfaces;

public class RoundInfo
{
    public Unit Attacker { get;}
    public Unit Defender { get;}
    public Unit SkillOwner { get; set; }
    public Unit Rival { get; set; }

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