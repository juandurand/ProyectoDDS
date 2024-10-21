using Fire_Emblem_Common.Enums;

namespace Fire_Emblem_Common.Effects;

public class DefPenaltyEffect:Effect
{
    private readonly int _defPenalty;

    public DefPenaltyEffect(int defPenalty)
        : base(EffectsApplyOrder.FirstOrder)
    {
        _defPenalty = defPenalty;
    }

    public override void ApplyEffect(Unit unit)
    {
        unit.Def.Penalty += _defPenalty;
    }
}