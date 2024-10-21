using Fire_Emblem_Common.Enums;

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