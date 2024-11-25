using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Models;

namespace Fire_Emblem_Common.Effects;

public class WrathEffect:Effect
{
    public WrathEffect()
        : base(EffectsApplyOrder.FirstOrder) {}
    
    public override void ApplyEffect(Unit unit)
    {
        int bonus = GetBonus(unit);
        
        unit.Spd.Bonus += bonus;
        unit.Atk.Bonus += bonus;
    }

    private int GetBonus(Unit unit)
    {
        int maxValue = 30;
        return Math.Min(Math.Max(unit.HealthStatus.HpBaseValue - unit.HealthStatus.ActualHpValue, 0), maxValue);
    }
}