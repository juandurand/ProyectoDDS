using Fire_Emblem_Common.EDDs.Managers;

namespace Fire_Emblem_Common.EDDs.Models;

public class HealthStatus
{
    public int HpBaseValue;
    public int ActualHpValue;

    public double PercentageOfDamageBonusAfterAttack;

    public int PenaltyBeforeCombat;
    public int PenaltyAfterCombat;
    public int PenaltyAfterCombatIfUnitAttacked;
    
    public int BonusAfterCombat;
    public int BonusAfterAttack;
    
    public HealthStatus(int initialValue)
    {
        HpBaseValue = initialValue;
        ActualHpValue = initialValue;

        HealthStatusManager.ResetEffects(this);
    }
}