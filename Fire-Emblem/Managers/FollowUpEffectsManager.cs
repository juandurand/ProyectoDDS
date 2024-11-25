using Fire_Emblem_Common.Models;
using Fire_Emblem_Common.Enums;

namespace Fire_Emblem.Managers;

public static class FollowUpEffectsManager
{
    public static FollowUpEffectsResult GetFollowUpEffects(FollowUpEffects followUpEffects)
    {
        ApplyFollowUpDenials(followUpEffects);
        
        if (followUpEffects.FollowUpGuarantees > followUpEffects.FollowUpDenials)
        {
            return FollowUpEffectsResult.Guaranteed;
        }
        
        if (followUpEffects.FollowUpDenials > followUpEffects.FollowUpGuarantees)
        {
            return FollowUpEffectsResult.Denied;
        }
        
        return FollowUpEffectsResult.Neutral;
    }
    
    private static void ApplyFollowUpDenials(FollowUpEffects followUpEffects)
    {
        if (followUpEffects.DenialOfFollowUpGuarantees)
        {
            followUpEffects.FollowUpGuarantees = 0;
        }
        
        if (followUpEffects.DenialOfFollowUpDenials)
        {
            followUpEffects.FollowUpDenials = 0;
        }
    }
    
    public static void ResetFollowUpEffects(FollowUpEffects followUpEffects)
    {
        followUpEffects.FollowUpGuarantees = 0;
        followUpEffects.FollowUpDenials = 0;
        followUpEffects.DenialOfFollowUpGuarantees = false;
        followUpEffects.DenialOfFollowUpDenials = false;
    }
}