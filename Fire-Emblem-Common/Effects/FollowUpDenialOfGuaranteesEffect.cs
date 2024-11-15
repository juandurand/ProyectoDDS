using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Effects;

public class FollowUpDenialOfGuaranteesEffect : Effect
{
    public FollowUpDenialOfGuaranteesEffect()
        : base(EffectsApplyOrder.SecondOrder) { }

    public override void ApplyEffect(Unit unit)
    {
        unit.FollowUpEffects.DenialOfFollowUpGuarantees = true;
    } 
}