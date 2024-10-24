using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Damage;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.EDDs.Managers;

public static class UnitManager
{
    public static int GetTotalStat(Unit unit, StatType stat, AttackType attackType)
    {
        switch (stat)
        {
            case StatType.Atk:
                return StatManager.GetTotalStat(unit.Atk, attackType);
            case StatType.Spd:
                return StatManager.GetTotalStat(unit.Spd, attackType);
            case StatType.Def:
                return StatManager.GetTotalStat(unit.Def, attackType);
            case StatType.Res:
                return StatManager.GetTotalStat(unit.Res, attackType);
            default:
                return unit.HealthStatus.ActualHpValue;
        }
    }
    
    public static void ResetEffects(Unit unit)
    {
        StatManager.ResetEffects(unit.Atk);
        StatManager.ResetEffects(unit.Spd);
        StatManager.ResetEffects(unit.Def);
        StatManager.ResetEffects(unit.Res);
        DamageEffectsController.ResetEffects(unit.DamageEffects);
    }
    
    public static void SetFirstAttack(Unit unit)
    {
        if (unit.FirstAttack == FirstAttack.HaveNotFirstAttacked)
        {
            unit.FirstAttack = FirstAttack.ActuallyFirstAttacking;
        }
        else if (unit.FirstAttack == FirstAttack.ActuallyFirstAttacking)
        {
            unit.FirstAttack = FirstAttack.AlreadyFirstAttacked;
        }
    }
    
    public static void SetFirstDefense(Unit unit)
    {
        if (unit.FirstDefense == FirstDefense.HaveNotFirstDefended)
        {
            unit.FirstDefense = FirstDefense.ActuallyFirstDefending;
        }
        else if (unit.FirstDefense == FirstDefense.ActuallyFirstDefending)
        {
            unit.FirstDefense = FirstDefense.AlreadyFirstDefended;
        }
    }
}