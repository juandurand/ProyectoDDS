using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Models;

namespace Fire_Emblem_Common.Effects;

public class CounterAttackDenialOfDenialEffect:Effect
{
    public CounterAttackDenialOfDenialEffect()
        : base(EffectsApplyOrder.SecondOrder) {}

    public override void ApplyEffect(Unit unit)
    {
        unit.DenialOfCounterAttackDenial = true;
    }
}