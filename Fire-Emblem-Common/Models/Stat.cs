namespace Fire_Emblem_Common.Models;

public class Stat
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

    public Stat(int baseValue)
    {
        BaseValue = baseValue;

        Bonus = 0;
        Penalty = 0;
        FirstAttackBonus = 0;
        FirstAttackPenalty = 0;
        FollowUpBonus = 0;
        FollowUpPenalty = 0;
        BonusNeutralized = false;
        PenaltyNeutralized = false;
    }
}