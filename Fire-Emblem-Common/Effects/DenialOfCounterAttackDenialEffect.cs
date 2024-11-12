using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Effects;

public class DenialOfCounterAttackDenialEffect:Effect
{
    public DenialOfCounterAttackDenialEffect()
        : base(EffectsApplyOrder.FirstOrder) {}

    public override void ApplyEffect(Unit unit)
    {
        unit.DenialOfCounterAttackDenial = true;
    }
}