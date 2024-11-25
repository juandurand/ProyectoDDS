using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Models;

namespace Fire_Emblem_Common.Effects;

public class HpBonusAfterRoundEffect:Effect
{
    private readonly int _hpBonusAfterRound;

    public HpBonusAfterRoundEffect(int hpBonusAfterRound)
        : base(EffectsApplyOrder.ThirdOrder)
    {
        _hpBonusAfterRound = hpBonusAfterRound;
    }

    public override void ApplyEffect(Unit unit)
    {
        unit.HealthStatus.BonusAfterRound += _hpBonusAfterRound;
    }
}