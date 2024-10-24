using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Effects;

public class AtkPenaltyEffect:Effect
{
    private readonly int _atkPenalty;

    public AtkPenaltyEffect(int atkPenalty)
        : base(EffectsApplyOrder.FirstOrder)
    {
        _atkPenalty = atkPenalty;
    }

    public override void ApplyEffect(Unit unit)
    {
        unit.Atk.Penalty += _atkPenalty;
    }
}