using Fire_Emblem_Common.Models;
using Fire_Emblem_Common.Enums;

namespace Fire_Emblem_Common.Helpers;

public static class HealthStatusHelper
{
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