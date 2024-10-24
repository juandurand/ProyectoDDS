using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.PersonalizedInterfaces;

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