using Fire_Emblem_Common.Enums;

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