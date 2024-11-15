using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Effects;

public class FollowUpGuaranteeEffect : Effect
{
    public FollowUpGuaranteeEffect()
        : base(EffectsApplyOrder.FirstOrder) { }

    public override void ApplyEffect(Unit unit)
    {
        unit.FollowUpEffects.FollowUpGuarantees++;
    } 
}