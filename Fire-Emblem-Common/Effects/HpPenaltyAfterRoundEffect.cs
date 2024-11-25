using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Models;

namespace Fire_Emblem_Common.Effects;

public class HpPenaltyAfterRoundEffect:Effect
{
    private readonly int _hpPenaltyAfterRound;

    public HpPenaltyAfterRoundEffect(int hpPenaltyAfterRound)
        : base(EffectsApplyOrder.ThirdOrder)
    {
        _hpPenaltyAfterRound = hpPenaltyAfterRound;
    }

    public override void ApplyEffect(Unit unit)
    {
        unit.HealthStatus.PenaltyAfterRound += _hpPenaltyAfterRound;
    }
}