using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Damage;

namespace Fire_Emblem_Common.Effects;

public class DivineRecreationEffectt:Effectt
{
    public DivineRecreationEffectt()
        : base(3) { }

    public override void ApplyEffect(Unit unit)
    {
        int extraDamage = GetExtraDamage(unit);

        if (unit.Attacking)
        {
            unit.DamageEffects.FollowUpBonus += extraDamage;
        }
        else
        {
            unit.DamageEffects.FirstAttackBonus += extraDamage;
        }
    }

    private int GetExtraDamage(Unit unit)
    {
        int originalDamage = DamageCalculator.GetDamageWithoutDamageReductions(unit.ActualOpponent, unit, AttackType.FirstAttack);
        int actualDamage = DamageCalculator.GetDamage(unit.ActualOpponent, unit, AttackType.FirstAttack);
        return originalDamage - actualDamage;
    }
}