namespace Fire_Emblem_Common;

public class RoundInfo
{
    public Unit Attacker { get; set; }
    public Unit Defender { get; set; }
    public Unit SkillOwner { get; set; }
    public Unit Rival { get; set; }

    public RoundInfo(Unit attacker, Unit defender)
    {
        Attacker = attacker;
        Defender = defender;
    }
}