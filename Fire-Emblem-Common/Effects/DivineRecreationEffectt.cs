using Fire_Emblem;

namespace Fire_Emblem_Common.Effects;

public class DivineRecreationEffectt:Effectt
{
    public DivineRecreationEffectt(string attackType = "All")
        : base(3) { }

    public override void ApplyEffect(Unit unit)
    {
        int originalDamage = DamageCalculator.GetDamageWithoutSkills(unit.ActualOpponent, unit, AttackType.FirstAttack);
        int actualDamage = DamageCalculator.GetDamage(unit.ActualOpponent, unit, AttackType.FirstAttack);
        int extraDamage = originalDamage - actualDamage;

        if (unit.Attacking)
        {
            unit.Damage.FollowUpBonus += extraDamage;
        }
        else
        {
            unit.Damage.FirstAttackBonus += extraDamage;
        }
    }
}