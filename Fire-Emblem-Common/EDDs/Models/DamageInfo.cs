using Fire_Emblem_Common.Enums;

namespace Fire_Emblem_Common.EDDs.Models;

public class DamageInfo
{
    public readonly Unit Attacker;
    public readonly Unit Defender;
    public readonly AttackType AttackType;

    public DamageInfo(Unit attacker, Unit defender, AttackType attackType)
    {
        Attacker = attacker;
        Defender = defender;
        AttackType = attackType;
    }
}