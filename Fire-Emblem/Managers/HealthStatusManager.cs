using Fire_Emblem_Common.Models;

namespace Fire_Emblem.Managers;

public static class HealthStatusManager
{
    public static void DealDamage(HealthStatus healthStatus, int damage)
    {
        healthStatus.ActualHpValue = Math.Max(0, healthStatus.ActualHpValue - damage);
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
    
    public static bool IsUnitAlive(HealthStatus healthStatus)
    {
        return healthStatus.ActualHpValue > 0;
    }

    public static void ApplyEffectsAfterRound(HealthStatus healthStatus)
    {
        int totalEffect = healthStatus.BonusAfterRound - healthStatus.PenaltyAfterRound - 
                          healthStatus.PenaltyAfterRoundIfUnitAttacked;
        
        if (IsUnitAlive(healthStatus))
        {
            healthStatus.ActualHpValue = Math.Min(healthStatus.ActualHpValue + totalEffect, healthStatus.HpBaseValue);
            healthStatus.ActualHpValue = Math.Max(healthStatus.ActualHpValue, 1);
        }
        else
        {
            ResetEffects(healthStatus);
        }
    }
    
    public static void ResetEffects(HealthStatus healthStatus)
    {
        ResetBonus(healthStatus);
        ResetPenalty(healthStatus);
    }

    private static void ResetBonus(HealthStatus healthStatus)
    {
        healthStatus.PercentageOfDamageBonusAfterAttack = 0;
        healthStatus.BonusAfterRound = 0;
        healthStatus.BonusAfterAttack = 0;
    }
    
    private static void ResetPenalty(HealthStatus healthStatus)
    {
        healthStatus.PenaltyAfterRound = 0;
        healthStatus.PenaltyBeforeRound = 0;
        healthStatus.PenaltyAfterRoundIfUnitAttacked = 0;
    }
}