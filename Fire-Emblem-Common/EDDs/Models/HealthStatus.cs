namespace Fire_Emblem_Common.EDDs.Models;

public class HealthStatus
{
    public int HpBaseValue;
    public int ActualHpValue;

    public double PercentageOfDamageBonusAfterAttack;
    public double PercentagePenaltyBeforeCombat;

    public int PenaltyBeforeCombat;
    public int PenaltyAfterCombat;
    
    public int BonusBeforeCombat;
    public int BonusAfterCombat;
    
    public HealthStatus(int initialValue)
    {
        HpBaseValue = initialValue;
        ActualHpValue = initialValue;

        PercentageOfDamageBonusAfterAttack = 0;
        PercentagePenaltyBeforeCombat = 0;
        
        PenaltyBeforeCombat = 0;
        PenaltyAfterCombat = 0;
        
        BonusBeforeCombat = 0;
        BonusAfterCombat = 0;
    }
}