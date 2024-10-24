using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Effects;

public class DamageReductionEffect:Effect
{
    private readonly int _damagePenalty;

    public DamageReductionEffect(int damagePenalty)
        : base(EffectsApplyOrder.SecondOrder)
    {
        _damagePenalty = damagePenalty;
    }

    public override void ApplyEffect(Unit unit)
    {
        unit.DamageEffects.Penalty += _damagePenalty;
    }
}