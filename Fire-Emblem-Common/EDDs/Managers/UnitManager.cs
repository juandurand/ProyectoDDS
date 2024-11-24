using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Damage;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.EDDs.Managers;

public static class UnitManager
{
    public static int GetTotalStat(Unit unit, StatType stat, AttackType attackType)
    {
        return stat switch
        {
            StatType.Atk => StatManager.GetTotalStat(unit.Atk, attackType),
            StatType.Spd => StatManager.GetTotalStat(unit.Spd, attackType),
            StatType.Def => StatManager.GetTotalStat(unit.Def, attackType),
            StatType.Res => StatManager.GetTotalStat(unit.Res, attackType),
            _ => unit.HealthStatus.ActualHpValue
        };
    }
    
    public static int GetBaseValue(Unit unit, StatType stat)
    {
        return stat switch
        {
            StatType.Atk => unit.Atk.BaseValue,
            StatType.Spd => unit.Spd.BaseValue,
            StatType.Def => unit.Def.BaseValue,
            StatType.Res => unit.Res.BaseValue,
            _ => unit.HealthStatus.ActualHpValue
        };
    }
    
    public static void ResetEffects(Unit unit)
    {
        ResetStatEffects(unit);
        ResetCounterAttackDenials(unit);
        DamageEffectsController.ResetEffects(unit.DamageEffects);
        HealthStatusManager.ResetEffects(unit.HealthStatus);
        FollowUpEffectsManager.ResetFollowUpEffects(unit.FollowUpEffects);
    }

    private static void ResetStatEffects(Unit unit)
    {
        StatManager.ResetEffects(unit.Atk);
        StatManager.ResetEffects(unit.Spd);
        StatManager.ResetEffects(unit.Def);
        StatManager.ResetEffects(unit.Res);
    }

    private static void ResetCounterAttackDenials(Unit unit)
    {
        unit.CounterAttackDenial = false;
        unit.DenialOfCounterAttackDenial = false;
    }
    
    public static void SetFirstAttack(Unit unit)
    {
        unit.FirstAttack = unit.FirstAttack switch
        {
            FirstAttack.HaveNotFirstAttacked => FirstAttack.ActuallyFirstAttacking,
            FirstAttack.ActuallyFirstAttacking => FirstAttack.AlreadyFirstAttacked,
            _ => unit.FirstAttack
        };
    }
    
    public static void SetFirstDefense(Unit unit)
    {
        unit.FirstDefense = unit.FirstDefense switch
        {
            FirstDefense.HaveNotFirstDefended => FirstDefense.ActuallyFirstDefending,
            FirstDefense.ActuallyFirstDefending => FirstDefense.AlreadyFirstDefended,
            _ => unit.FirstDefense
        };
    }
    
    public static void SetPenaltyAfterRoundIfUnitAttacked(Unit unit)
    {
        if (!unit.Attacked)
        {
            unit.HealthStatus.PenaltyAfterRoundIfUnitAttacked = 0;
        }
    }
    
    public static void SetAttacked(Unit unit)
    {
        unit.Attacked = true;
    }
    
    public static void ResetAttacked(Unit unit)
    {
        unit.Attacked = false;
    }
}