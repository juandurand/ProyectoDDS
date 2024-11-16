using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Damage;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Effects;

public class BrashAssaultEffect:Effect
{
    public BrashAssaultEffect()
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

        int actualDamage = DamageCalculator.GetDamageWithoutDamageReductions(damageInfo);
        
        return Convert.ToInt32(Math.Floor(actualDamage * 0.3));
    }
}