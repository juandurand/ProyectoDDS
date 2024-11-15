using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Effects;

public class HpPercentageBonusOfDamageEffect:Effect
{
    private readonly double _percentageOfDamage;

    public HpPercentageBonusOfDamageEffect(double percentageOfDamage)
        : base(EffectsApplyOrder.SecondOrder)
    {
        _percentageOfDamage = percentageOfDamage;
    }

    public override void ApplyEffect(Unit unit)
    {
        unit.HealthStatus.PercentageOfDamageBonusAfterAttack += _percentageOfDamage;
    }
}