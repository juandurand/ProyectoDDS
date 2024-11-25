namespace Fire_Emblem_Common.Models;

public class HealthStatus
{
    public int HpBaseValue;
    public int ActualHpValue;

    public double PercentageOfDamageBonusAfterAttack;

    public int PenaltyBeforeRound;
    public int PenaltyAfterRound;
    public int PenaltyAfterRoundIfUnitAttacked;
    
    public int BonusAfterRound;
    public int BonusAfterAttack;
    
    public HealthStatus(int initialValue)
    {
        HpBaseValue = initialValue;
        ActualHpValue = initialValue;

        PercentageOfDamageBonusAfterAttack = 0.0;
        PenaltyBeforeRound = 0;
        PenaltyAfterRound = 0;
        PenaltyAfterRoundIfUnitAttacked = 0;
        BonusAfterRound = 0;
        BonusAfterAttack = 0;
    }
}