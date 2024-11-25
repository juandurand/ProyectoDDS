using Fire_Emblem_Common.EDDs.Managers;

namespace Fire_Emblem_Common.EDDs.Models;

public class FollowUpEffects
{
    public int FollowUpGuarantees;
    public int FollowUpDenials;
    
    public bool DenialOfFollowUpGuarantees;
    public bool DenialOfFollowUpDenials;
    
    public FollowUpEffects()
    {
        FollowUpEffectsManager.ResetFollowUpEffects(this);
    }
}