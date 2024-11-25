namespace Fire_Emblem_Common.Models;

public class FollowUpEffects
{
    public int FollowUpGuarantees;
    public int FollowUpDenials;
    
    public bool DenialOfFollowUpGuarantees;
    public bool DenialOfFollowUpDenials;
    
    public FollowUpEffects()
    {
        FollowUpGuarantees = 0;
        FollowUpDenials = 0;
        DenialOfFollowUpGuarantees = false;
        DenialOfFollowUpDenials = false;
    }
}