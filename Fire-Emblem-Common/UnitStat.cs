namespace Fire_Emblem_Common;

public class UnitStat
{
    public readonly int BaseValue;
    
    public int Bonus;
    public int Penalty;
    public int FirstAttackBonus;
    public int FirstAttackPenalty;
    public int FollowUpBonus;
    public int FollowUpPenalty;
    
    public bool BonusNeutralized;
    public bool PenaltyNeutralized;

    public UnitStat(int baseValue)
    {
        BaseValue = baseValue;
        ResetEffects();
    }
    public void ResetEffects()
    {
        ResetBonus();
        ResetPenalty();
    }

    private void ResetBonus()
    {
        Bonus = 0;
        FirstAttackBonus = 0;
        FollowUpBonus = 0;
        BonusNeutralized = false;
    }
    
    private void ResetPenalty()
    {
        Penalty = 0;
        FirstAttackPenalty = 0;
        FollowUpPenalty = 0;
        PenaltyNeutralized = false;
    }
    
    public int GetTotalStat(AttackType attackType)
    {
        int totalStat = BaseValue;
    
        if (!BonusNeutralized)
        {
            totalStat += Bonus;
            if (attackType == AttackType.FirstAttack) totalStat += FirstAttackBonus;
            if (attackType == AttackType.FollowUp) totalStat += FollowUpBonus;
        }
        
        if (!PenaltyNeutralized)
        {
            totalStat -= Penalty;
            if (attackType == AttackType.FirstAttack) totalStat -= FirstAttackPenalty;
            if (attackType == AttackType.FollowUp) totalStat -= FollowUpPenalty;
        }
        
        return totalStat;
    }
}