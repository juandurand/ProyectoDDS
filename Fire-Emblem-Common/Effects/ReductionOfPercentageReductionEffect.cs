using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Effects;

public class ReductionOfPercentageReductionEffect : Effect
{
    private readonly double _reduction;
    
    public ReductionOfPercentageReductionEffect(double reduction)
        : base(EffectsApplyOrder.SecondOrder)
    {
        _reduction = reduction;
    }
    
    public override void ApplyEffect(Unit unit)
    {
        unit.DamageEffects.ReductionOfPercentageReduction *= (1 - _reduction);
    }
}