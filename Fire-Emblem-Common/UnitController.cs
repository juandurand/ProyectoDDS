using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Damage;

namespace Fire_Emblem_Common;

public static class UnitController
{
    public static int GetTotalStat(Unit unit, StatType stat, AttackType attackType)
    {
        switch (stat)
        {
            case StatType.Atk:
                return StatController.GetTotalStat(unit.Atk, attackType);
            case StatType.Spd:
                return StatController.GetTotalStat(unit.Spd, attackType);
            case StatType.Def:
                return StatController.GetTotalStat(unit.Def, attackType);
            case StatType.Res:
                return StatController.GetTotalStat(unit.Res, attackType);
            default:
                return unit.HealthStatus.ActualHpValue;
        }
    }
    
    public static void ResetEffects(Unit unit)
    {
        StatController.ResetEffects(unit.Atk);
        StatController.ResetEffects(unit.Spd);
        StatController.ResetEffects(unit.Def);
        StatController.ResetEffects(unit.Res);
        DamageEffectsController.ResetEffects(unit.DamageEffects);
    }
    
    public static void SetFirstAttack(Unit unit)
    {
        if (unit.FirstAttack == 0 || unit.FirstAttack == 1)
        {
            unit.FirstAttack += 1;
        }
    }
    
    public static void SetFirstDefense(Unit unit)
    {
        if (unit.FirstDefense == 0 || unit.FirstDefense == 1)
        {
            unit.FirstDefense += 1;
        }
    }
}