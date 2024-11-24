using Fire_Emblem_Common.EDDs.Managers;

namespace Fire_Emblem_Common.EDDs.Models;

public class HealthStatus
{
    public int HpBaseValue;
    public int ActualHpValue;

    public double PercentageOfDamageBonusAfterAttack;

    public int PenaltyBeforeRound;
    public int PenaltyAfterRound;
    public int PenaltyAfterRoundIfUnitAttacked;
    
    public int BonusAfterCombat;
    public int BonusAfterAttack;
    
    public HealthStatus(int initialValue)
    {
        HpBaseValue = initialValue;
        ActualHpValue = initialValue;

        HealthStatusManager.ResetEffects(this);
    }
}