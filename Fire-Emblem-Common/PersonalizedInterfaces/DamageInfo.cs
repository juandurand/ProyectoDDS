using Fire_Emblem_Common.Enums;

namespace Fire_Emblem_Common.PersonalizedInterfaces;

public class DamageInfo
{
    public Unit Attacker { get; set; }
    public Unit Defender { get; set;  }
    public AttackType AttackType { get; }

    public DamageInfo(Unit attacker, Unit defender, AttackType attackType)
    {
        Attacker = attacker;
        Defender = defender;
        AttackType = attackType;
    }

    public void SwitchUnits()
    {
        (Attacker, Defender) = (Defender, Attacker);
    }
}