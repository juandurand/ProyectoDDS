using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Damage;
using Fire_Emblem_Common.Models;

namespace Fire_Emblem_Common.Effects;

public class DivineRecreationEffect:Effect
{
    public DivineRecreationEffect()
        : base(EffectsApplyOrder.ThirdOrder) { }

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
        DamageInfo damageInfo = new DamageInfo(unit.ActualOpponent, unit, AttackType.FirstAttack);
        
        int originalDamage = DamageCalculator.GetDamageWithoutDamageReductions(damageInfo);
        int actualDamage = DamageCalculator.GetDamage(damageInfo);
        
        return originalDamage - actualDamage;
    }
}