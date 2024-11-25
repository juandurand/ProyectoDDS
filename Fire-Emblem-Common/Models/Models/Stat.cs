using Fire_Emblem_Common.EDDs.Managers;

namespace Fire_Emblem_Common.EDDs.Models;

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
        StatManager.ResetEffects(this);
    }
}