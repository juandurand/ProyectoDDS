using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Models;

namespace Fire_Emblem.Managers;

public static class UnitManager
{
    public static void ResetEffects(Unit unit)
    {
        ResetStatEffects(unit);
        ResetCounterAttackDenials(unit);
        DamageEffectsManager.ResetEffects(unit.DamageEffects);
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