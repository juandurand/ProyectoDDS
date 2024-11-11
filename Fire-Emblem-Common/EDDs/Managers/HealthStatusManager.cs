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
}