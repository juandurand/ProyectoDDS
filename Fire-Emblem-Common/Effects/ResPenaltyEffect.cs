using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Effects;

public class ResPenaltyEffect:Effect
{
    private readonly int _resPenalty;

    public ResPenaltyEffect(int resPenalty)
        : base(EffectsApplyOrder.FirstOrder)
    {
        _resPenalty = resPenalty;
    }

    public override void ApplyEffect(Unit unit)
    {
        unit.Res.Penalty += _resPenalty;
    }
}