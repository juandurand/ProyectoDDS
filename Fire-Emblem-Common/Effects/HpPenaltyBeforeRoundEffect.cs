using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Models;

namespace Fire_Emblem_Common.Effects;

public class HpPenaltyBeforeRoundEffect:Effect
{
    private readonly int _hpPenaltyBeforeRound;

    public HpPenaltyBeforeRoundEffect(int hpPenaltyBeforeRound)
        : base(EffectsApplyOrder.ThirdOrder)
    {
        _hpPenaltyBeforeRound = hpPenaltyBeforeRound;
    }

    public override void ApplyEffect(Unit unit)
    {
        unit.HealthStatus.PenaltyBeforeRound += _hpPenaltyBeforeRound;
        unit.HealthStatus.ActualHpValue = Math.Max(unit.HealthStatus.ActualHpValue - _hpPenaltyBeforeRound, 1);
    }
}