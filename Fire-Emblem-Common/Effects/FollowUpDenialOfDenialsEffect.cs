using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Models;

namespace Fire_Emblem_Common.Effects;

public class FollowUpDenialOfDenialsEffect : Effect
{
    public FollowUpDenialOfDenialsEffect()
        : base(EffectsApplyOrder.SecondOrder) { }

    public override void ApplyEffect(Unit unit)
    {
        unit.FollowUpEffects.DenialOfFollowUpDenials = true;
    } 
}