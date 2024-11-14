using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.EDDs.Managers;

public static class HealthStatusManager
{
    public static bool IsUnitAlive(HealthStatus healthStatus)
    {
        return healthStatus.ActualHpValue > 0;
    }
    
    public static void DealDamage(HealthStatus healthStatus, int damage)
    {
        healthStatus.ActualHpValue = Math.Max(0, healthStatus.ActualHpValue - damage);
    }
    
    public static double GetHpPercentage(HealthStatus healthStatus)
    {
        return (double)healthStatus.ActualHpValue / healthStatus.HpBaseValue;
    }

    public static void ApplyHpBaseValueBonus(HealthStatus healthStatus, int hpBonus)
    {
        healthStatus.HpBaseValue += hpBonus;
        healthStatus.ActualHpValue = healthStatus.HpBaseValue;
    }

    public static void ResetEffects(HealthStatus healthStatus)
    {
        ResetBonus(healthStatus);
        ResetPenalty(healthStatus);
    }

    private static void ResetBonus(HealthStatus healthStatus)
    {
        healthStatus.PercentageOfDamageBonusAfterAttack = 0;
        healthStatus.BonusAfterCombat = 0;
        healthStatus.BonusAfterAttack = 0;
    }
    
    private static void ResetPenalty(HealthStatus healthStatus)
    {
        healthStatus.PercentagePenaltyBeforeCombat = 0;
        healthStatus.PenaltyAfterCombat = 0;
        healthStatus.PenaltyBeforeCombat = 0;
        healthStatus.PenaltyAfterCombatIfUnitAttacked = 0;
    }

    public static void ApplyPercentageOfDamageBonusAfterAttack(HealthStatus healthStatus, int damage)
    {
        healthStatus.BonusAfterAttack = Convert.ToInt32(Math.Floor(
                                        damage * healthStatus.PercentageOfDamageBonusAfterAttack));
        if (IsUnitAlive(healthStatus)) 
        {
            healthStatus.ActualHpValue = Math.Min(healthStatus.ActualHpValue + healthStatus.BonusAfterAttack,
                                                  healthStatus.HpBaseValue);
        }
    }

    public static void ApplyEffectsAfterRound(HealthStatus healthStatus)
    {
        int totalEffect = healthStatus.BonusAfterCombat - healthStatus.PenaltyAfterCombat - 
                          healthStatus.PenaltyAfterCombatIfUnitAttacked;
        if (IsUnitAlive(healthStatus))
        {
            healthStatus.ActualHpValue = Math.Min(healthStatus.ActualHpValue + totalEffect, healthStatus.HpBaseValue);
            healthStatus.ActualHpValue = Math.Max(healthStatus.ActualHpValue, 1);
        }
        else
        {
            healthStatus.BonusAfterCombat = 0;
            healthStatus.PenaltyAfterCombat = 0;
            healthStatus.PenaltyAfterCombatIfUnitAttacked = 0;
        }
    }
}