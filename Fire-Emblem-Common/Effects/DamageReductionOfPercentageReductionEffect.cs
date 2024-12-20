using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Models;

namespace Fire_Emblem_Common.Effects;

public class DamageReductionOfPercentageReductionEffect : Effect
{
    private readonly double _reduction;
    
    public DamageReductionOfPercentageReductionEffect(double reduction)
        : base(EffectsApplyOrder.FirstOrder)
    {
        _reduction = reduction;
    }
    
    public override void ApplyEffect(Unit unit)
    {
        unit.DamageEffects.ReductionOfPercentageReduction *= (1 - _reduction);
    }
}