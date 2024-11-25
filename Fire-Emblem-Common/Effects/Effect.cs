using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Models;

namespace Fire_Emblem_Common.Effects;

public abstract class Effect
{
    public EffectsApplyOrder ApplyOrder { get; }
    
    protected Effect(EffectsApplyOrder applyOrder)
    {
        ApplyOrder = applyOrder;
    }
    
    public abstract void ApplyEffect(Unit unit);
}