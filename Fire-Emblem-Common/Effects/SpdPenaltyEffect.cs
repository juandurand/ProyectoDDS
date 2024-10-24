using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Effects;

public class SpdPenaltyEffect:Effect
{
    private readonly int _spdPenalty;

    public SpdPenaltyEffect(int spdPenalty)
        : base(EffectsApplyOrder.FirstOrder)
    {
        _spdPenalty = spdPenalty;
    }

    public override void ApplyEffect(Unit unit)
    {
        unit.Spd.Penalty += _spdPenalty;
    }
}